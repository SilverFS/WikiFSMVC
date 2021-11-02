using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using MvcCore.Models;
using DAL.DTO;
using BusinessLogic.Interfaces;

namespace MvcCore.Controllers
{
    public class PageController : Controller
    {
        private readonly ILogger<PageController> _logger;
        private readonly string _connectionString;

        public PageController(ILogger<PageController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            textContainer = new DAL.PageDAL(_connectionString);

        }

        //public List<Page> GetallText()
        //{
        //    List<Page> allText = new List<Page>();

        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("SELECT ID, Title, Text FROM TextTable", connection);
        //        {
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    allText.Add(new Page
        //                    {
        //                        ID = Convert.ToInt32(reader["ID"].ToString()),
        //                        Title = reader["Title"].ToString(),
        //                        Text = reader["Text"].ToString()
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    return allText;
        //}

        //public Page GetPage(int ID)
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("SELECT ID, Title, Text FROM TextTable WHERE ID=@ID", connection);
        //        {
        //            command.Parameters.AddWithValue("ID", ID);
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    return new Page
        //                    {
        //                        ID = Convert.ToInt32(reader["ID"].ToString()),
        //                        Title = reader["Title"].ToString(),
        //                        Text = reader["Text"].ToString()
        //                    };
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}

        //public void CreatePage(Page page)
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("INSERT INTO TextTable (Title, Text) VALUES (@Title, @Text)", connection);
        //        {
        //            if (page.Title == null)
        //            {
        //                command.Parameters.AddWithValue("Title", DBNull.Value);
        //            }
        //            else
        //            {
        //                command.Parameters.AddWithValue("Title", page.Title);
        //            }
        //            if (page.Text == null)
        //            {
        //                command.Parameters.AddWithValue("Text", DBNull.Value);
        //            }
        //            else
        //            {
        //                command.Parameters.AddWithValue("Text", page.Text);
        //            }
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void DeletePage(int ID)
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("DELETE FROM TextTable WHERE ID=@ID", connection);
        //        {
        //            command.Parameters.AddWithValue("ID", ID);

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}



        //public void EditPage(Page page)
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("UPDATE TextTable SET Title= @Title, Text = @Text WHERE ID=@ID", connection);
        //        {
        //            if (page.Title == null)
        //            {
        //                command.Parameters.AddWithValue("Title", DBNull.Value);
        //            }
        //            else
        //            {
        //                command.Parameters.AddWithValue("Title", page.Title);
        //            }
        //            if (page.Text == null)
        //            {
        //                command.Parameters.AddWithValue("Text", DBNull.Value);
        //            }
        //            else
        //            {
        //                command.Parameters.AddWithValue("Text", page.Text);
        //            }
        //            command.Parameters.AddWithValue("ID", page.ID);

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}


        private DAL.PageDAL textContainer;
        public IActionResult Index()
        {
            return View(textContainer.GetallText());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Page page)
        {
            textContainer.CreatePage(page);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int ID)
        {
            textContainer.DeletePage(ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            return View(textContainer.GetPage(ID));
        }
        
        public IActionResult Edit(Page page, int ID)
        {
            page.ID = ID;
            textContainer.EditPage(page);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
