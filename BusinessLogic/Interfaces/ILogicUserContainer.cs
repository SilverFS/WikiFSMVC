using MvcCore.Models;

namespace BusinessLogic.Interfaces
{
    public interface ILogicUserContainer
    {
        //UserModel GetUser(int ID);
        void CreateUser(UserModel user);
    }
}
