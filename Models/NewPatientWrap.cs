using System.Collections.Generic;

namespace organProject.Models{
    public class NewPatientWrap
    {
        public User ThisUser {get;set;}
        public Recipient NewRecipient {get;set;}
        public List<Center> AllCenter {get;set;}
    }
}