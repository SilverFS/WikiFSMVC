using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiFSUnitTests.Mockups
{
    public class PageDALMockup : IPage, IPageContainer
    {
        public void CreatePage(PageDTO page)
        {
            throw new NotImplementedException();
        }

        public void DeletePage(int ID)
        {
            throw new NotImplementedException();
        }

        public void EditPage(PageDTO page)
        {
            throw new NotImplementedException();
        }

        public List<PageDTO> GetallText()
        {
            List<PageDTO> list = new List<PageDTO>();
            list.Add(new PageDTO());
            list.Add(new PageDTO());
            return list;
        }

        public PageDTO GetPage(int ID)
        {
            PageDTO page = new PageDTO
            {
                ID = ID
            };
            return page;
        }
    }
}
