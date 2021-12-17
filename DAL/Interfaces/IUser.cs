using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IUser
    {
        void UpdateUser(UserDTO user);
        void DeleteUser(int ID);
    }
}
