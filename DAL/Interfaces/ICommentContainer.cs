using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICommentContainer
    {
        void CreateComment(CommentDTO comment);
        public void DeleteComment(int ID);

    }
}
