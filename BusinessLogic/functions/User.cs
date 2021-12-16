using BusinessLogic.Interfaces;
using DAL.Interfaces;
using MvcCore.Converters;
using MvcCore.Models;
using System;

namespace BusinessLogic.functions
{
    public class User : ILogicUser
    {
        private readonly IUser _User;
        readonly UserConverter _UserConverter;
        /// <summary>
        /// Depends on and expects given interfaces(IPage) which realizes within the given DAL. So essentially, this class (Page) needs IPage and PageConverter to work.
        /// </summary>
        /// <param name="SQLUserContext"></param>
        public User(IUser SQLUserContext, UserConverter userConverter)
        {
            _User = SQLUserContext;
            _UserConverter = userConverter;
        }
        public void DeleteUser(int ID)
        {
            _User.DeleteUser(ID);
        }

        public void UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
