using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface ILogicUser
    {
        void UpdateUser(UserModel user);
        void DeleteUser(int ID);
    }
}
