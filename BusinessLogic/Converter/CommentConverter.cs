using BusinessLogic.Models;
using DAL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Converter
{
    public class CommentConverter
    {

        //Method overloading :)
        /// <summary>
        /// Takes values from CommentModel and converts them equal to values from CommentDTO.
        /// </summary>
        /// <param name="commentModel"></param>
        /// <returns></returns>
        public CommentDTO Convert_To_DTO_CommentModel(CommentModel commentModel)
        {
            return new CommentDTO
            {
                ID = commentModel.ID,
                Text = commentModel.Text,
                created_at = commentModel.created_at,
                user_id = commentModel.user_id,
                page_id = commentModel.page_id,
            };
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the PageModel to a list with PageDTO. 
        /// </summary>
        /// <param name="pageModels"></param>
        /// <returns></returns>
        public List<CommentDTO> Convert_To_DTO_CommentModel(List<CommentModel> commentModels)
        {
            return commentModels.Select(x => Convert_To_DTO_CommentModel(x)).ToList();
        }


        /// <summary>
        /// Takes values from CommentDTO and converts them equal to values from CommentModel.
        /// </summary>
        /// <param name="dTO_CommentModel"></param>
        /// <returns></returns>
        public CommentModel Convert_To_CommentModel(CommentDTO dTO_CommentModel)
        {
            return new CommentModel
            {
                ID = dTO_CommentModel.ID,
                Text = dTO_CommentModel.Text,
                created_at = dTO_CommentModel.created_at,
                user_id = dTO_CommentModel.user_id,
                page_id = dTO_CommentModel.page_id,
            };
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the PageModel to a list with PageDTO. 
        /// </summary>
        /// <param name="pageModels"></param>
        /// <returns></returns>
        public List<CommentModel> Convert_To_CommentModel(List<CommentDTO> commentModels)
        {
            return commentModels.Select(x => Convert_To_CommentModel(x)).ToList();
        }
    }
}
