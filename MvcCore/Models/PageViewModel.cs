using System;
using System.Collections.Generic;

namespace MvcCore.Models
{
    public class PageViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<CommentViewModel> comments { get; set; }
    }
}
