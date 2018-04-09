using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.IdentityModel.Tokens;
using FinalProject.Models;
using FinalProject.Data;

namespace FinalProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                // Use MySql package for connection (may require restart of VSCode)
            options => options.UseMySql(
                    // Use appsettings.json ConnectionStrings: DefaultConnection
                    // NOTE: You should add appsettings.json to .gitIgnore to prevent 
                    //      settings from being visible in public repositories
            Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            //Add check for pending migrations to database
            //Try/Catch for catching when migration created causes error
            try
            {
                var context = serviceProvider.GetService<ApplicationDbContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.TeamMembers.Any())
                {
                    context.TeamMembers.Add(new TeamMembers { NameFirst = "Reginald", NameLast = "Beason", About = "Reginald", Title = "Beason"});
                    context.TeamMembers.Add(new TeamMembers { NameFirst = "Marshall", NameLast = "Frink", About = "Marshall", Title = "Frink" });
                    context.TeamMembers.Add(new TeamMembers { NameFirst = "Sheryl", NameLast = "Choun", About = "Sheryl", Title = "Choun" });
                    context.TeamMembers.Add(new TeamMembers { NameFirst = "Luis", NameLast = "Lopez", About = "Luis", Title = "Lopez" });
                    context.SaveChanges();
                }
                if (!context.PageContents.Any())
                {
                    context.PageContents.Add(new PageContent{ Title = "Welcome", Description = "Check your sleeping schedule", PageName = "HomePage"});
                    context.SaveChanges();
                }
            }
            catch (Exception ex){
                Console.WriteLine("Unable to seed database.");
                Console.WriteLine(ex.Message);
            }


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Initialize(app.ApplicationServices);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
