using MvcCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcCore.Converters
{
    public class UserViewConverter
    {
        //Method overloading :)
        /// <summary>
        /// Takes values from UserModel and converts them equal to values from UserViewModel.
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public UserViewModel Convert_To_UserViewModel(UserModel userModel)
        {
            return new UserViewModel
            {
                ID = userModel.ID,
                UserName = userModel.UserName,
                Email = userModel.Email,
                Password = userModel.Password,
                created_at = userModel.created_at,
            };
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the UserModel to a list with UserViewModel. 
        /// </summary>
        /// <param name="userModels"></param>
        /// <returns></returns>
        //public List<UserViewModel> Convert_To_UserViewModel(List<UserModel> userModels)
        //{
        //    return userModels.Select(x => Convert_To_UserViewModel(x)).ToList();
        //}

        /// <summary>
        /// Takes values from UserViewModel and converts them equal to values from UserModel.
        /// </summary>
        /// <param name="userView"></param>
        /// <returns></returns>
        public UserModel Convert_To_UserModel(UserViewModel userView)
        {
            return new UserModel
            {
                ID = userView.ID,
                UserName = userView.UserName,
                Email = userView.Email,
                Password = userView.Password,
                created_at = userView.created_at,
            };
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the UserViewModel to a list with UserModel.
        /// </summary>
        /// <param name="userView"></param>
        /// <returns></returns>
        //public List<UserModel> Convert_To_UserModel(List<UserViewModel> userView)
        //{
        //    return userView.Select(x => Convert_To_UserModel(x)).ToList();
        //}
    }
}
