using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface ILogicPageContainer
    {
        List<PageModel> GetallText();
        PageModel GetPage(int ID);
        void CreatePage(PageModel page);

    }
}
