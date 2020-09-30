using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//*******************************
using System.Text.RegularExpressions;
//************************************

namespace organProject.Models
{
    public class User
    {
        [Key]
        public int UserID {get;set;}


        [Required(ErrorMessage="First name must be longer than 2 characters")]
        [Display(Name="First Name: ")]
        public string FirstName {get;set;}


        [Required(ErrorMessage="Last name must be longer than 2 characters")]
        [Display(Name="Last Name: ")]
        public string LastName {get; set;}


        [Required(ErrorMessage="Please enter a valid Email address")]
        [EmailAddress]
        [Display(Name="Email: ")]
        public string Email {get;set;}
        

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer")]
        [Display(Name="Password: ")]
//***********************************************************************
        // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")]
//*******************************************************************************
        public string Password {get;set;}


        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password: ")]
        public string Confirm {get;set;}
    }
}