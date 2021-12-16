using System;

namespace DAL.DTO
{
    public class CommentDTO
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime created_at { get; set; }
        public int user_id { get; set; }
        public int page_id { get; set; }
    }
}
