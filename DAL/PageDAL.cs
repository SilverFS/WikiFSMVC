using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Text;
using InterfaceLayer.DTO;



namespace DAL
{
    public class PageDAL 
    {

        private readonly string _connectionString;

        public PageDAL(string configuration)
        {
            _connectionString = configuration;
        }


        public List<Page> GetallText()
        {
            List<Page> allText = new List<Page>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ID, Title, Text FROM TextTable", connection);
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allText.Add(new Page
                            {
                                ID = Convert.ToInt32(reader["ID"].ToString()),
                                Title = reader["Title"].ToString(),
                                Text = reader["Text"].ToString()
                            });
                        }
                    }
                }
            }
            return allText;
        }


        public Page GetPage(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ID, Title, Text FROM TextTable WHERE ID=@ID", connection);
                {
                    command.Parameters.AddWithValue("ID", ID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Page
                            {
                                ID = Convert.ToInt32(reader["ID"].ToString()),
                                Title = reader["Title"].ToString(),
                                Text = reader["Text"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }


        public void CreatePage(Page page)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO TextTable (Title, Text) VALUES (@Title, @Text)", connection);
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
                    command.ExecuteNonQuery();
                }
            }
        }


        public void DeletePage(int ID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM TextTable WHERE ID=@ID", connection);
                {
                    command.Parameters.AddWithValue("ID", ID);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditPage(Page page)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE TextTable SET Title= @Title, Text = @Text WHERE ID=@ID", connection);
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

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
