﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishForKidAPI.Models
{
    public class BaseDataObject
    {
        [Key]
        public Guid ID { get; set; }
    }
}
