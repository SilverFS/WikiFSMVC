using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Contexts
{
    public class SQLCommentContext : ICommentContainer
    {
        private SqlConnection _connection;

        public SQLCommentContext(SqlConnection configuration)
        {
            _connection = configuration;
        }


        public List<CommentDTO> GetallComments()
        {
            List<CommentDTO> allComments = new List<CommentDTO>();



            _connection.Open();
            SqlCommand command = new SqlCommand("SELECT comment_id, text, created_at, user_id, page_id FROM comments", _connection);
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allComments.Add(new CommentDTO
                        {
                            ID = Convert.ToInt32(reader["comment_id"].ToString()),
                            Text = reader["text"].ToString(),
                            created_at = (DateTime)reader["created_at"],
                            user_id = Convert.ToInt32(reader["user_id"].ToString()),
                            page_id = Convert.ToInt32(reader["page_id"].ToString())

                        });
                    }
                }
            }
            _connection.Close();
            return allComments;
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
            SqlCommand command = new SqlCommand("DELETE FROM users WHERE user_id=@ID", _connection);
            {
                command.Parameters.AddWithValue("ID", ID);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}
