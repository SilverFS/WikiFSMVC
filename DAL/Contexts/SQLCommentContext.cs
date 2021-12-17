using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Data.SqlClient;

namespace DAL.Contexts
{
    public class SQLCommentContext : ICommentContainer
    {
        private readonly SqlConnection _connection;

        public SQLCommentContext(SqlConnection configuration)
        {
            _connection = configuration;
        }



        public void CreateComment(CommentDTO comment)
        {
            _connection.Open();
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO comments (text, created_at, user_id, page_id) VALUES (@Text, @created_at, @user_id, @page_id)", _connection);
                {
                    command.Parameters.AddWithValue("text", comment.Text);
                    command.Parameters.AddWithValue("created_at", DateTime.Now);
                    command.Parameters.AddWithValue("user_id", DBNull.Value);
                    command.Parameters.AddWithValue("page_id", comment.page_id);
                    command.ExecuteNonQuery();
                }
                _connection.Close();
            }
            catch (Exception)
            {
                _connection.Close();

                throw;
            }

        }

        public void DeleteComment(int ID)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM comments WHERE comment_id=@ID", _connection);
            {
                command.Parameters.AddWithValue("ID", ID);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}
