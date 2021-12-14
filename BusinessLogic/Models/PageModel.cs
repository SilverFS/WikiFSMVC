using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;

namespace BusinessLogic.Models
{
    public class PageModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}
