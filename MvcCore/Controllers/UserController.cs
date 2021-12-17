using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Converters;
using MvcCore.Models;

namespace MvcCore.Controllers
{
    public class UserController : Controller
    {
        // 
        private readonly ILogicUserContainer _UserContainer;
        private readonly ILogicUser _CredUser;
        private readonly UserViewConverter _UserViewConverter = new UserViewConverter();

        public UserController(ILogicUserContainer userContainer, ILogicUser credUser)
        {
            _UserContainer = userContainer;
            _CredUser = credUser;
        }

        public IActionResult GetUser(int ID)
        {
            return View(_UserContainer.GetUser(ID));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserViewModel user)
        {
            try
            {
                var modelCreate = _UserViewConverter.Convert_To_UserModel(user);
                _UserContainer.CreateUser(modelCreate);
                return RedirectToAction("Index", "Page");
            }
            catch (System.Exception)
            {
                ViewBag.message = ("<div class=\"alert alert-warning text-center my-4\">Email already exists! 🌶</div>");
                return View();
            }

        }

    }
}
