using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class FeedbackReplyHistory:BaseDataObject
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid FeedbackID { get; set; }
    }
}