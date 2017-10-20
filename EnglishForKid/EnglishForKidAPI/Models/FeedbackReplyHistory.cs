using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("FeedbackReplyHistory")]
    public class FeedbackReplyHistory:BaseDataObject
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid FeedbackID { get; set; }
    }
}