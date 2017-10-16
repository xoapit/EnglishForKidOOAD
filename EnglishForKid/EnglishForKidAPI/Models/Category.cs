﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("Category")]
    public class Category : BaseDataObject
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}