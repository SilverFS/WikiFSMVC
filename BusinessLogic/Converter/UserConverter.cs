using DAL.DTO;
using MvcCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcCore.Converters
{
    public class UserConverter
    {
        //Method overloading :)
        /// <summary>
        /// Takes values from UserModel and converts them equal to values from UserDTO.
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public UserDTO Convert_To_DTO_UserModel(UserModel userModel)
        {
            return new UserDTO
            {
                ID = userModel.ID,
                UserName = userModel.UserName,
                Email = userModel.Email,
                Password = userModel.Password,
                created_at = userModel.created_at,
            };
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the UserModel to a list with UserDTO. 
        /// </summary>
        /// <param name="pageModels"></param>
        /// <returns></returns>
        //public List<UserDTO> Convert_To_DTO_UserModel(List<UserModel> pageModels)
        //{
        //    return pageModels.Select(x => Convert_To_DTO_UserModel(x)).ToList();
        //}

        /// <summary>
        /// Takes values from UserDTO and converts them equal to values from UserModel.
        /// </summary>
        /// <param name="dTO_PageModel"></param>
        /// <returns></returns>
        public UserModel Convert_To_UserModel(UserDTO dTO_PageModel)
        {
            return new UserModel
            {
                ID = dTO_PageModel.ID,
                UserName = dTO_PageModel.UserName,
                Email = dTO_PageModel.Email,
                Password = dTO_PageModel.Password,
                created_at = dTO_PageModel.created_at,
            };
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the UserDTO to a list with UserModel.
        /// </summary>
        /// <param name="dTO_PageModels"></param>
        /// <returns></returns>
        //public List<UserModel> Convert_To_UserModel(List<UserDTO> dTO_PageModels)
        //{
        //    return dTO_PageModels.Select(x => Convert_To_UserModel(x)).ToList();
        //}
    }
}
