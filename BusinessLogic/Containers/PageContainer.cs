 using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Converter;
using System.Linq;

namespace BusinessLogic.Containers
{
    public class PageContainer
    {
        private IPageContainer _Pages;
        private PageConverter _PageConverter = new PageConverter();
        public PageContainer(IPageContainer PageDAL)
        {
            _Pages = PageDAL;
        }
        public List<PageModel> GetallText()
        {           
            List<PageModel> allText = _PageConverter.Convert_To_PageModel(_Pages.GetallText());
            return allText;
        }

        public PageModel GetPage(int ID)
        {
            PageModel page = _PageConverter.Convert_To_PageModel(_Pages.GetPage(ID));
            return page;
        }

        public void CreatePage(PageModel page)
        {
            _Pages.CreatePage(_PageConverter.Convert_To_DTO_PageModel(page));
        }

    }
}
