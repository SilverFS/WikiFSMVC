using BusinessLogic.Models;
using MvcCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcCore.Converters
{
    public class CommentViewConverter
    {
        //Method overloading :)
        /// <summary>
        /// Takes values from CommentModel and converts them equal to values from CommentViewModel.
        /// </summary>
        /// <param name="commentModel"></param>
        /// <returns></returns>
        public CommentViewModel Convert_To_CommentViewModel(CommentModel commentModel)
        {
            return new CommentViewModel
            {
                ID = commentModel.ID,
                Text = commentModel.Text,
                created_at = commentModel.created_at,
                user_id = commentModel.user_id,
                page_id = commentModel.page_id,
            };
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the CommentModel to a list with CommentViewModel. 
        /// </summary>
        /// <param name="userModels"></param>
        /// <returns></returns>
        public List<CommentViewModel> Convert_To_CommentViewModel(List<CommentModel> userModels)
        {
            return userModels.Select(x => Convert_To_CommentViewModel(x)).ToList();
        }

        /// <summary>
        /// Takes values from CommentViewModel and converts them equal to values from CommentModel.
        /// </summary>
        /// <param name="commentView"></param>
        /// <returns></returns>
        public CommentModel Convert_To_CommentModel(CommentViewModel commentView)
        {
            return new CommentModel
            {
                ID = commentView.ID,
                Text = commentView.Text,
                created_at = commentView.created_at,
                user_id = commentView.user_id,
                page_id = commentView.page_id,
            };
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the CommentViewModel to a list with CommentModel.
        /// </summary>
        /// <param name="commentView"></param>
        /// <returns></returns>
        public List<CommentModel> Convert_To_CommentModel(List<CommentViewModel> commentView)
        {
            return commentView.Select(x => Convert_To_CommentModel(x)).ToList();
        }
    }
}
