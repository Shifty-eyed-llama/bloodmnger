using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace organProject.Models{
    public class DashWrapper
    {
        public User ThisUser {get;set;}
        public List<Donor> AllDonors {get;set;}
    }
}