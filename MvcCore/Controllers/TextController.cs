using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using MvcCore.Models;

namespace MvcCore.Controllers
{
    public class TextController : Controller
    {

        private readonly string _connectionString;

        public TextController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<TextModel> GetallText()
        {
            List<TextModel> allText = new List<TextModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ID, Title, Text FROM TextTable", connection);
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allText.Add(new TextModel
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
            

        
        public IActionResult Index()
        {
            return View(GetallText());
        }
    }
}
