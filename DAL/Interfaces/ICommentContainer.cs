using DAL.DTO;

namespace DAL.Interfaces
{
    public interface ICommentContainer
    {
        void CreateComment(CommentDTO comment);
        public void DeleteComment(int ID);

    }
}
