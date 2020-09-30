//location, patient list, see if there are any ABO matches

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace organProject.Models
{
    public class Center
    {
        [Key]

        public int CenterID {get;set;}

        public string CenterName {get;set;}

        public List<Recipient> Recipients {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}