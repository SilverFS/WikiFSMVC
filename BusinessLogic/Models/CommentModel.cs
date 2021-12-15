using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime created_at { get; set; }
        public int user_id { get; set; }
        public int page_id { get; set; }
    }
}
