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
using DAL.Contexts;
using MvcCore.Converters;
using BusinessLogic.Interfaces;

namespace MvcCore.Controllers
{
    public class PageController : Controller
    {
        // 
        private readonly ILogicPageContainer _textContainer;
        private readonly ILogicPage _textPage;
        private PageViewConverter _PageViewConverter = new PageViewConverter();
        private CommentViewConverter _CommentViewConverter = new CommentViewConverter();

        public PageController(ILogicPageContainer pageContainer, ILogicPage textPage)
        {
            _textContainer = pageContainer;
            _textPage = textPage;
        }



        //public IActionResult Page(int ID)
        //{
        //    return View(_textContainer.GetPage(ID));
        //}

        public IActionResult Index()
        {
            var model = new IndexPageViewModel
            {
                pages = _PageViewConverter.Convert_To_PageViewModel(_textContainer.GetallText()),
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PageViewModel page)
        {
            var modelCreate = _PageViewConverter.Convert_To_PageModel(page);
            _textContainer.CreatePage(modelCreate);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int ID)
        {
            _textPage.Delete(ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var edit = _PageViewConverter.Convert_To_PageViewModel(_textContainer.GetPage(ID));
            return View(edit);
        }

        public IActionResult Edit(PageViewModel page)
        {
            var updated = _PageViewConverter.Convert_To_PageModel(page);
            _textPage.Update(updated);
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
