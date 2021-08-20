using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace personal_inforamtion_system_new.Models
{
    public class PersonalInfo
    {
        public int pid { get; set; }
        public string Salutation { get; set; }
        public string firstName { get; set; }
      
        public string LastName { get; set; }
       
        public string Email { get; set; }
       
        public string Age { get; set; }
        
        public string Gender { get; set; }
       
        public string PhoneNumber { get; set; }
        
        
        
        public string Nationality { get; set; }
        //[Required]
        //public string AddressId { get; set; }


        public virtual List<Address> Addresslist { get; set; }
        public virtual List<Education> Educationlist { get; set; }
    }
    public class Education
    {
        public string chosenEdu { get; set; }
        
    }




}