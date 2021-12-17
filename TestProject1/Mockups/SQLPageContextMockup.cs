using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace WikiFSUnitTests.Mockups
{
    public class SQLPageContextMockup : IPage, IPageContainer
    {
        public void CreatePage(PageDTO page)
        {
            //throw new NotImplementedException();
            PageDTO pageDTO = new PageDTO();
            pageDTO.Title = page.Title;
            pageDTO.Text = page.Text;
            pageDTO.created_at = DateTime.Now;
            pageDTO.updated_at = DateTime.Now;
            return;
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
            // create an empty dto list
            List<PageDTO> list = new List<PageDTO>();
            // add empty pageDTO's
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
