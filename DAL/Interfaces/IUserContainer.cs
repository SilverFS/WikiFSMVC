using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IUserContainer
    {
        UserDTO GetUser(int ID);
        void CreateUser(UserDTO user);
    }
}
