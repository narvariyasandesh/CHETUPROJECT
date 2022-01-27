﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CHETUPROJECT.Models
{
    // Add profile data for application users by adding properties to the AuthUser class
    public class AuthUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string mobile { get; set; }
    }
}
