using BusinessLogic.Converter;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DAL.Interfaces;
using System;

namespace BusinessLogic.Containers
{
    public class CommentContainer : ILogicCommentContainer
    {
        private readonly ICommentContainer _Comments;
        private readonly CommentConverter _CommentConverter;
        /// <summary>
        /// Depends on and expects given interfaces(IPageContainer) which realizes within the given DAL
        /// </summary>
        /// <param name="SQLCommentContext"></param>
        public CommentContainer(ICommentContainer SQLCommentContext, CommentConverter commentConverter)
        {
            _Comments = SQLCommentContext;
            _CommentConverter = commentConverter;
        }

        public void CreateComment(CommentModel comment)
        {
            try
            {
                _Comments.CreateComment(_CommentConverter.Convert_To_DTO_CommentModel(comment));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteComment(int ID)
        {
            _Comments.DeleteComment(ID);
        }
    }
}
