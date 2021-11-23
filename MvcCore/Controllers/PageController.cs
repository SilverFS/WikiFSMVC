using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using MvcCore.Models;
using DAL;
using Factory;

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

        
        private DAL.PageDAL textContainer;

        public IActionResult Page(int ID)
        {
            return View(textContainer.GetPage(ID));
        }
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
        public IActionResult Create(Factory.DTO.PageDTO page)
        {
            textContainer.CreatePage(page);
            return RedirectToAction("Index");
        }

        [HttpGet]
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
        
        public IActionResult Edit(Factory.DTO.PageDTO page, int ID)
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
