using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface ILogicCommentContainer
    {
        void CreateComment(CommentModel comment);
        public void DeleteComment(int ID);

    }
}
