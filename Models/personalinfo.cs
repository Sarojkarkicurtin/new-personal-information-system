using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace personal_inforamtion_system_new.Models
{
    public class personalinfo
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string AddressId { get; set; }


        public virtual List<Address> Address { get; set; }
    }
    
}