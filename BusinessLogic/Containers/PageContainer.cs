 using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Converter;
using System.Linq;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Containers
{
    public class PageContainer : ILogicPageContainer
    {
        private IPageContainer _Pages;
        private PageConverter _PageConverter;
        /// <summary>
        /// Depends on and expects given interfaces(IPageContainer) which realizes within the given DAL
        /// </summary>
        /// <param name="PageDAL"></param>
        public PageContainer(IPageContainer PageDAL, PageConverter pageConverter)
        {
            _Pages = PageDAL;
            _PageConverter = pageConverter;
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
