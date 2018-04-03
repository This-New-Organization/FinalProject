using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels.Account
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Username { get; set; }
        
        //Requiring a user to have a password
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        //Asking to remember the user as they log in.
        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
