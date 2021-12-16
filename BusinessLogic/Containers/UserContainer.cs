using BusinessLogic.Interfaces;
using DAL.Interfaces;
using MvcCore.Converters;
using MvcCore.Models;

namespace BusinessLogic.Containers
{
    public class UserContainer : ILogicUserContainer
    {
        private readonly IUserContainer _User;
        private readonly UserConverter _UserConverter;
        /// <summary>
        /// Depends on and expects given interfaces(IPageContainer) which realizes within the given DAL
        /// </summary>
        /// <param name="SQLUserContext"></param>
        public UserContainer(IUserContainer SQLUserContext, UserConverter userConverter)
        {
            _User = SQLUserContext;
            _UserConverter = userConverter;
        }
        public void CreateUser(UserModel user)
        {
            _User.CreateUser(_UserConverter.Convert_To_DTO_UserModel(user));
        }

        public UserModel GetUser(int ID)
        {
            UserModel user = _UserConverter.Convert_To_UserModel(_User.GetUser(ID));
            return user;
        }
    }
}
