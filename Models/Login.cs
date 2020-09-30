using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//*******************************
using System.Text.RegularExpressions;
//************************************

namespace organProject.Models
{
    
    public class LoginUser
    {
        [Required(ErrorMessage="This simply wont work without a login.")]
        [EmailAddress]
        [Display(Name="Email: ")]
        public string Email {get;set;}

        [Required(ErrorMessage="Did you not use a password when you registered?")]
        [DataType(DataType.Password)]
        [Display(Name="Password: ")]
        public string Password {get;set;}
    }
}