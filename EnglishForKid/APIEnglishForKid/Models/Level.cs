﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class Level : BaseDataObject
    {
        public int Value { get; set; }
        
        public string Description { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public Level()
        {
            Lessons = new List<Lesson>();
        }
    }
}