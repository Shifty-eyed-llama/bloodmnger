using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace organProject.Models{
    public class FacilityDashWrapper
    {
        public User ThisUser {get;set;}
        public List<Recipient> AllRecipient {get;set;}

        public List<Center> AllCenter {get;set;}
    }
}