using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace organProject.Models
{
    public class Donor
    {
        [Key]

        public int DonorID {get;set;}

        [Required(ErrorMessage="If unknown use UNKOWN")]
        [Display(Name="Donor First Name: ")]
        public string FirstName {get;set;}


        [Required(ErrorMessage="If unknown use UNKOWN")]
        [Display(Name="Donor Last Name: ")]
        public string LastName {get;set;}


        [DataType(DataType.Date)]
        [Display(Name="Date Of Birth: ")]
        public DateTime DOB {get;set;}


        [Required(ErrorMessage="You Missed this.")]
        [Display(Name="Blood Type: ")]
        public char BloodType {get;set;}


        [Required(ErrorMessage="You Missed this")]
        [Display(Name="Rh: ")]
        public bool Rh {get;set;}


        [Required]
        [Display(Name="Registered: ")]
        public bool Registered {get;set;}


        [Required]
        [Display(Name="Consent: ")]
        public bool Consent {get;set;}


    
        [Display(Name="Case Notes: ")]
        public string Notes {get;set;}

        [Display(Name="Current Hospital: ")]
        public string CurrentHosp {get;set;}

        public int HospitalID {get;set;} // current hospital
        public Center CurrentCenter {get;set;} // current hospital

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}