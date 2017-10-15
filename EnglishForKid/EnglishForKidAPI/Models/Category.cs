using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [DataContract]
    public class Category
    {
        [DataMember]
        [Key]
        public Guid ID { get; set; }

        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public string Description { get; set; }
    }
}