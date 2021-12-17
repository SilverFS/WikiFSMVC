using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace WikiFSUnitTests.Mockups
{
    public class SQLPageContextMockup : IPage, IPageContainer
    {
        public List<PageDTO> pageList = new List<PageDTO>();
        public SQLPageContextMockup()
        {
            pageList.Add(new PageDTO
            {
                ID = 1,
                Title = "Original Title",
                Text = "Some content bruh",
                updated_at = DateTime.Now,
            });
        }



        public void CreatePage(PageDTO page)
        {
            //throw new NotImplementedException();

            PageDTO pageDTO = new PageDTO();
            pageDTO.Title = page.Title;
            pageDTO.Text = page.Text;
            pageDTO.created_at = DateTime.Now;
            pageDTO.updated_at = DateTime.Now;
            pageList.Add(pageDTO);
            return;
        }

        public void DeletePage(int ID)
        {
            foreach (PageDTO item in pageList)
            {
                if (item.ID == ID)
                {
                    pageList.RemoveAt(ID);
                    return;
                }
            }
        }

        public void EditPage(PageDTO page)
        {
            foreach (PageDTO item in pageList)
            {
                if (item.ID == page.ID)
                {
                    pageList[item.ID - 1] = page;
                    return;
                }
            }
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
