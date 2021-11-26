using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using MvcCore.Models;
using BusinessLogic.Models;
using BusinessLogic.Containers;
using DAL.DALS;
using MvcCore.Converters;

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
            textContainer = new PageContainer(new PageDAL(_connectionString));
            
        }

        
        private PageContainer textContainer;
        private PageViewConverter _PageViewConverter = new PageViewConverter();


        public IActionResult Page(int ID)
        {
            return View(textContainer.GetPage(ID));
        }
        public IActionResult Index()
        {
            var model = new IndexPageViewModel
            {
                pages = _PageViewConverter.Convert_To_PageViewModel(textContainer.GetallText())
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PageModel page)
        {
            textContainer.CreatePage(page);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            PageModel page = textContainer.GetPage(ID);
            page.Delete();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            return View(textContainer.GetPage(ID));
        }
        
        public IActionResult Edit(PageModel page)
        {
            page.Update();
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
