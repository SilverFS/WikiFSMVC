using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public interface IPage
    {
        public void EditPage();
        public void GetPage(int ID);
    }
}
