using DAL.DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IPageContainer
    {
        List<PageDTO> GetallText();
        PageDTO GetPage(int ID);
        void CreatePage(PageDTO page);

    }
}
