﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace personal_inforamtion_system_new.Models
{
    public class detail
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public string firstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Age { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }



        public string Nationality { get; set; }
    }
}