using BusinessLogic.Converter;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Containers
{
    public class PageContainer : ILogicPageContainer
    {
        private readonly IPageContainer _Pages;
        private readonly PageConverter _PageConverter;
        /// <summary>
        /// Depends on and expects given interfaces(IPageContainer) which realizes within the given DAL
        /// </summary>
        /// <param name="PageDAL"></param>
        public PageContainer(IPageContainer SQLPageContext, PageConverter pageConverter)
        {
            _Pages = SQLPageContext;
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
            try
            {
                _Pages.CreatePage(_PageConverter.Convert_To_DTO_PageModel(page));
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
