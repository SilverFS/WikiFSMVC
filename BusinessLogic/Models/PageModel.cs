using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using BusinessLogic.Converter;

namespace BusinessLogic.Models
{
    public class PageModel
    {
        private IPage _Page;
        private PageConverter _PageConverter = new PageConverter();
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public void Delete()
        {
            _Page.DeletePage(this.ID);
        }

        public void Update()
        {
            _Page.EditPage(_PageConverter.Convert_To_DTO_PageModel(this));
        }
    }

    
}
