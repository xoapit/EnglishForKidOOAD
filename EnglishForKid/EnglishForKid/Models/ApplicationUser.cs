﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class ApplicationUser
    {
        public string UserName { get; set; }
        public string Id { get; set; }
        public string FullName { get; set; }
        public string[] Roles { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }

    }
}