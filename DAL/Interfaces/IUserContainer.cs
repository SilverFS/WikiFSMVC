using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserContainer
    {
        UserDTO GetUser(int ID);
        void CreateUser(UserDTO user);
    }
}
