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
            pageList.Add(page);
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

            // add empty pageDTO's
            return pageList;
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
