using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace personal_inforamtion_system_new.Models
{
    public class Address
    {
       
        [Required]
        public string AddressType { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string City { get; set; }
        [Required]

        public string Ward { get; set; }
        [Required]
        public string Tole { get; set; }
    }
}