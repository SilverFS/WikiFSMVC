using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public interface IPageContainer
    {
        public void GetallText();
        public void CreatePage();
        public void DeletePage();
    }
}
