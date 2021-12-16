using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;
using DAL.Interfaces;
using DAL.DTO;




namespace DAL.Contexts
{
    public class SQLPageContext : IPageContainer, IPage
    {

        private SqlConnection _connection;

        public SQLPageContext(SqlConnection configuration)
        {
            _connection = configuration;
        }


        public List<PageDTO> GetallText()
        {
            List<PageDTO> allText = new List<PageDTO>();
            List<CommentDTO> allComments = new List<CommentDTO>();



            _connection.Open();
            SqlCommand command = new SqlCommand("SELECT p.page_id, p.title, p.text, p.created_at, p.updated_at, " +
                "c.comment_id, c.text AS content, c.created_at AS created_on, c.user_id, c.page_id " +
                "FROM pages AS p LEFT JOIN comments AS c ON (p.page_id = c.page_id ) " +
                "ORDER BY c.created_at DESC;", _connection);
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var lastPage = 0;
                    while (reader.Read())
                    {
                        if (lastPage != Convert.ToInt32(reader["page_id"].ToString()))
                        {
                            allComments = new List<CommentDTO>();
                            allText.Add(new PageDTO
                            {
                                ID = Convert.ToInt32(reader["page_id"].ToString()),
                                Title = reader["title"].ToString(),
                                Text = reader["text"].ToString(),
                                created_at = (DateTime)reader["created_at"],
                                updated_at = (DateTime)reader["updated_at"],
                                comments = allComments
                            });
                            lastPage = Convert.ToInt32(reader["page_id"].ToString());
                        }


                        if (!DBNull.Value.Equals(reader["comment_id"]))
                        {
                            allComments.Add(new CommentDTO
                            {
                                ID = Convert.ToInt32(reader["comment_id"].ToString()),
                                Text = reader["content"].ToString(),
                                created_at = (DateTime)reader["created_on"],
                                //user_id = Convert.ToInt32(reader["user_id"].ToString()),
                                page_id = Convert.ToInt32(reader["page_id"].ToString())

                            });
                        }


                    }
                }
            }
            _connection.Close();
            return allText;
        }

        /// <summary>
        /// Useful for getting a single page.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>Returns the ID, Title and Text of a page.</returns>
        public PageDTO GetPage(int ID)
        {

            _connection.Open();
            SqlCommand command = new SqlCommand("SELECT page_id, title, text FROM pages WHERE page_id=@ID", _connection);
            {
                command.Parameters.AddWithValue("ID", ID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PageDTO page = new PageDTO
                        {
                            ID = Convert.ToInt32(reader["page_id"].ToString()),
                            Title = reader["title"].ToString(),
                            Text = reader["text"].ToString()
                        };
                        _connection.Close();
                        return page;
                    }
                }
            }
            _connection.Close();
            return null;
        }

        /// <summary>
        /// Creates a page in the PageDAL.
        /// </summary>
        /// <param name="page"></param>
        public void CreatePage(PageDTO page)
        {

            _connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO pages (title, text, created_at, updated_at) VALUES (@Title, @Text, @created_at, @updated_at)", _connection);
            {
                if (page.Title == null)
                {
                    command.Parameters.AddWithValue("Title", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("Title", page.Title);
                }
                if (page.Text == null)
                {
                    command.Parameters.AddWithValue("Text", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("Text", page.Text);
                }

                command.Parameters.AddWithValue("created_at", DateTime.Now);
                command.Parameters.AddWithValue("updated_at", DateTime.Now);

                command.ExecuteNonQuery();
            }
            _connection.Close();
        }


        public void DeletePage(int ID)
        {

            _connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM pages WHERE page_id=@ID", _connection);
            {
                command.Parameters.AddWithValue("ID", ID);

                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void EditPage(PageDTO page)
        {

            _connection.Open();
            SqlCommand command = new SqlCommand("UPDATE pages SET title= @Title, text = @Text, updated_at= @updated_at WHERE page_id=@ID", _connection);
            {
                if (page.Title == null)
                {
                    command.Parameters.AddWithValue("Title", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("Title", page.Title);
                }
                if (page.Text == null)
                {
                    command.Parameters.AddWithValue("Text", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("Text", page.Text);
                }
                command.Parameters.AddWithValue("ID", page.ID);
                command.Parameters.AddWithValue("updated_at", DateTime.Now);

                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

    }
}