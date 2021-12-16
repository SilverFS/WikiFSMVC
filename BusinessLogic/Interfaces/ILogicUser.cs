using MvcCore.Models;

namespace BusinessLogic.Interfaces
{
    public interface ILogicUser
    {
        void UpdateUser(UserModel user);
        void DeleteUser(int ID);
    }
}
