using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Converters;
using MvcCore.Models;
using System.Diagnostics;

namespace MvcCore.Controllers
{
    public class PageController : Controller
    {
        private readonly ILogicPageContainer _textContainer;
        private readonly ILogicPage _textPage;
        private readonly PageViewConverter _PageViewConverter = new PageViewConverter();

        public PageController(ILogicPageContainer pageContainer, ILogicPage textPage)
        {
            _textContainer = pageContainer;
            _textPage = textPage;
        }



        public IActionResult Index(int activePage = 0)
        {

            var model = new IndexPageViewModel
            {
                pages = _PageViewConverter.Convert_To_PageViewModel(_textContainer.GetallText()),
                activePage = activePage
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
            return RedirectToAction(nameof(PageController.Index), new { activePage = page.ID });
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
