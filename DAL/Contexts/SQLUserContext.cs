using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Contexts
{
    public class SQLUserContext : IUser, IUserContainer
    {
        private SqlConnection _connection;

        public SQLUserContext(SqlConnection configuration)
        {
            _connection = configuration;
        }


        public void CreateUser(UserDTO user)
        {
            _connection.Open();
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO users (username, email, password, created_at) VALUES (@UserName, @Email, @Password, @created_at)", _connection);
                {
                    command.Parameters.AddWithValue("UserName", user.UserName);
                    command.Parameters.AddWithValue("Email", user.Email);
                    command.Parameters.AddWithValue("Password", user.Password);
                    command.Parameters.AddWithValue("created_at", DateTime.Now);
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

        public void DeleteUser(int ID)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM users WHERE user_id=@ID", _connection);
            {
                command.Parameters.AddWithValue("ID", ID);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public UserDTO GetUser(int ID)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand("SELECT user_id, username, email, password, created_at FROM users WHERE user_id=@ID", _connection);
            {
                command.Parameters.AddWithValue("ID", ID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserDTO page = new UserDTO
                        {
                            ID = Convert.ToInt32(reader["user_id"].ToString()),
                            UserName = reader["username"].ToString(),
                            Email = reader["email"].ToString(),
                            Password = reader["password"].ToString()
                        };
                        _connection.Close();
                        return page;
                    }
                }
            }
            _connection.Close();
            return null;
        }

        public void UpdateUser(UserDTO user)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand("UPDATE users SET username= @UserName, email = @Email, password= @Password WHERE user_id=@ID", _connection);
            {

                command.Parameters.AddWithValue("UserName", user.UserName);
                command.Parameters.AddWithValue("Text", user.Email);
                command.Parameters.AddWithValue("Password", user.Password);
                command.Parameters.AddWithValue("ID", user.ID);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}
