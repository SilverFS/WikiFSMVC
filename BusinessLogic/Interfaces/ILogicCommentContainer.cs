using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface ILogicCommentContainer
    {
        void CreateComment(CommentModel comment);
        public void DeleteComment(int ID);

    }
}
