using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface ILogicUserContainer
    {
        UserModel GetUser(int ID);
        void CreateUser(UserModel user);
    }
}
