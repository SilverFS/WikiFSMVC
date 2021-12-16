using BusinessLogic.Models;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface ILogicPageContainer
    {
        List<PageModel> GetallText();
        PageModel GetPage(int ID);
        void CreatePage(PageModel page);

    }
}
