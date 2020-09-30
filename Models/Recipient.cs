using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace organProject.Models
{
    public class Recipient
    {
        [Key]

        public int RecipientID {get;set;}

        [Required(ErrorMessage="Patient name required")]
        [Display(Name="Patient First Name: ")]
        public string FirstName {get;set;}


        [Required(ErrorMessage="Patient last name required")]
        [Display(Name="Patient Last Name: ")]
        public string LastName {get;set;}


        [DataType(DataType.Date)]
        [Display(Name="Date Of Birth: ")]
        public DateTime DOB {get;set;}


        [Required]
        [Display(Name="Blood Type: ")]
        public char BloodType {get;set;}


        [Required]
        [Display(Name="Rh: ")]
        public bool Rh {get;set;}


        [Display(Name="Case Notes: ")]
        public string Notes {get;set;}

        public int CenterID {get;set;} // current hospital
        public Center CurrentCenter {get;set;} // current hospital

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}