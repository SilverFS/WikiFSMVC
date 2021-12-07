using BusinessLogic.Converter;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface ILogicPage
    {
        void Update(PageModel pageModel);
        void Delete(int ID);
    }
}
