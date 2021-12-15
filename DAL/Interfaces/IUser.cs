using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUser
    {
        void UpdateUser(UserDTO user);
        void DeleteUser(int ID);
    }
}
