using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace organProject.Models{
    public class MatchWrap
    {
        public User ThisUser {get;set;}
        public Donor ThisDonor {get;set;}
        public List<Recipient> Potential {get;set;}
    }
}