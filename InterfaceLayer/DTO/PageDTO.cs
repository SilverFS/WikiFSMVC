using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLayer.DTO
{
    public class PageDTO : IPageDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
