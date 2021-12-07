using System;
using System.Collections.Generic;
using System.Text;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IPage
    {
        void EditPage(PageDTO page);
        void DeletePage(int ID);
    }
}
