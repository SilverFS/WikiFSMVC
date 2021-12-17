using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace WikiFSUnitTests.Mockups
{
    public class SQLCommentContextMockup : ICommentContainer
    {
        public List<CommentDTO> commentList = new List<CommentDTO>();
        public SQLCommentContextMockup()
        {
            commentList.Add(new CommentDTO
            {
                ID = 1,
                Text = "Some content bruh",
                created_at = DateTime.Now,
                page_id = 2,
            });
        }

        public void CreateComment(CommentDTO comment)
        {
            commentList.Add(comment);
            return;
        }

        public void DeleteComment(int ID)
        {
            foreach (CommentDTO item in commentList)
            {
                if (item.ID == ID)
                {
                    commentList.RemoveAt(ID);
                    return;
                }
            }
        }
    }
}
