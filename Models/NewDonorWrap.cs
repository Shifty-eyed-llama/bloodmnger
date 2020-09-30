using System.Collections.Generic;

namespace organProject.Models{
    public class NewDonorWrap
    {
        public User ThisUser {get;set;}
        public Donor NewDonor {get;set;}
        public List<Center> AllCenter {get;set;}
    }
}