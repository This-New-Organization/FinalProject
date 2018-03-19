using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
   
    public class CCFPContext : DbContext
    {
        //data tables 
        
        public DbSet<TeamMembers> TeamMembers { get; set; }
        public DbSet<ContactForm> ContactForm { get; set; }
        
        public CCFPContext(DbContextOptions<CCFPContext> options)
            : base(options)
        {
        }

    }
}