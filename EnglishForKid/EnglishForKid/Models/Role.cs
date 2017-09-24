﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class Role : BaseDataObject
    {
        public string RoleName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Authority> Authorities { get; set; }

        public Role()
        {
            Authorities = new List<Authority>();
        }
    }
}