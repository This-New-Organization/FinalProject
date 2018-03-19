using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NameFirst { get; set; }  
        public string NameLast { get; set; }    
        
    }

}