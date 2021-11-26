using System;
using System.Collections.Generic;
using System.Text;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IPageContainer
    {
        List<PageDTO> GetallText();
        PageDTO GetPage(int ID);
        void CreatePage(PageDTO page);
        
    }
}
