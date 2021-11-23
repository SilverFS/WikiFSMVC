using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public interface IConnectionString
    {
        public void PageDAL(string configuration);
    }
}
