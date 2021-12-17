using System;
using System.Collections.Generic;

namespace DAL.DTO
{
    public class PageDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int user_id { get; set; }
        public int folder_id { get; set; }
        public List<CommentDTO> comments { get; set; }
    }
}
