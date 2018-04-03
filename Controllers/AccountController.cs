using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using FinalProject.Models;
using FinalProject.ViewModels.Account;

// namespace FinalProject.Controllers
// {
//     [Authorize]
//     [Route("api/[controller]")]
//     public class AccountController : Controller
//     {
//         private readonly UserManager<ApplicationUser> _userManager;
//         private readonly SignInManager<ApplicationUser> _signInManager;
//         private readonly ILogger _logger;

//         public AccountController(
//             UserManager<ApplicationUser> userManager,
//             SignInManager<ApplicationUser> signInManager,
//             ILoggerFactory loggerFactory)
//         {
//             _userManager = userManager;
//             _signInManager = signInManager;
//             _logger = loggerFactory.CreateLogger<AccountController>();
//         }
//     }

//             private async Task<UserViewModel> GetUser(string userName)
//         { 
//             var user = await _userManager.FindByNameAsync(userName);
//             var claims = await _userManager.GetClaimsAsync(user);
//             var vm = new UserViewModel
//             {
//                 UserName = user.UserName,
//                 Claims = claims.ToDictionary(c => c.Type, c => c.Value)
//             };
//             return vm;
//         }

//         //
//         // POST: /Account/Login
//         [HttpPost("login")]
//         [AllowAnonymous]
//         public async Task<IActionResult> Login([FromBody]LoginViewModel model, string returnUrl = null)
//         {
//             ViewData["ReturnUrl"] = returnUrl;
//             if (ModelState.IsValid)
//             {
//                 // This doesn't count login failures towards account lockout
//                 // To enable password failures to trigger account lockout, set lockoutOnFailure: true

//                 Microsoft.AspNetCore.Identity.SignInResult result;

//                 if(String.IsNullOrEmpty(model.Email))
//                 {
//                     result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
//                     if (result.Succeeded)
//                     {
//                         _logger.LogInformation(1, "User logged in.");
//                         var user = await GetUser(model.UserName);
//                         return Ok(user);
//                     }
//                 }
//                 else
//                 {
//                     result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
//                     if (result.Succeeded)
//                     {
//                         _logger.LogInformation(1, "User logged in.");
//                         var user = await GetUser(model.Email);
//                         return Ok(user);
//                     }
//                 }

//                 //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
//                 //if (result.Succeeded)
//                 //{
//                 //    _logger.LogInformation(1, "User logged in.");
//                 //    var user = await GetUser(model.Email);
//                 //    return Ok(user);
//                 //}
//                 if (result.RequiresTwoFactor)
//                 {
//                     return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
//                 }
//                 if (result.IsLockedOut)
//                 {
//                     _logger.LogWarning(2, "User account locked out.");
//                     this.ModelState.AddModelError("", "User account locked out.");
//                     return BadRequest(this.ModelState);
//                 }
//                 else
//                 {
//                     ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//                     return BadRequest(this.ModelState);
//                 }
//             }

//             // If we got this far, something failed, redisplay form
//             return BadRequest(this.ModelState);
//         }


//         //
//         // POST: /Account/Register
//         [HttpPost("Register")]
//         [AllowAnonymous]
//         public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
//         {
//             if (ModelState.IsValid)
//             {
//                 var user = new ApplicationUser
//                 {
//                     UserName = model.UserName,
//                     Email = model.Email,
//                     NameFirst = model.NameFirst,
//                     NameLast = model.NameLast,

//                 };
//                 var result = await _userManager.CreateAsync(user, model.Password);
//                 if (result.Succeeded)
//                 {
//                     // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
//                     // Send an email with this link
//                     //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                     //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
//                     //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
//                     //    "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
//                     await _signInManager.SignInAsync(user, isPersistent: false);
//                     _logger.LogInformation(3, "User created a new account with password.");
//                     var userViewModel = await GetUser(user.UserName);
//                     return Ok(userViewModel);
//                 }
//                 AddErrors(result);
//             }

//             // If we got this far, something failed
//             return BadRequest(this.ModelState);
//         }



//         [HttpGet("checkAuthentication")]
//         [AllowAnonymous]
//         public async Task<IActionResult> CheckAuthentication()
//         {
//             if (this._signInManager.IsSignedIn(this.User))
//             {
//                 var userViewModel = await GetUser(this.User.Identity.Name);
//                 return Ok(userViewModel);
//             }
//             return Ok();
//         }


//         //
//         // POST: /Account/LogOff
//         [HttpPost("logout")]
//         public async Task<IActionResult> Logout()
//         {
//             await _signInManager.SignOutAsync();
//             _logger.LogInformation(4, "User logged out.");
//             return Ok();
//         }
// }