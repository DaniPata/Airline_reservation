﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Models
{
    public class User: IdentityUser
    {
  
  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPhoto { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }

    }
}
