using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Converters;
using MvcCore.Models;

namespace MvcCore.Controllers
{
    public class CommentController : Controller
    {
        // 
        private readonly ILogicCommentContainer _commentContainer;
        private readonly CommentViewConverter _CommentViewConverter = new CommentViewConverter();

        public CommentController(ILogicCommentContainer commentContainer)
        {
            _commentContainer = commentContainer;
        }



        [HttpPost]
        public IActionResult Create(CommentViewModel comment)
        {
            var modelCreate = _CommentViewConverter.Convert_To_CommentModel(comment);
            _commentContainer.CreateComment(modelCreate);
            return Redirect(Request.Headers["Referer"].ToString());
        }


        [HttpGet]
        public IActionResult Delete(int ID)
        {
            _commentContainer.DeleteComment(ID);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
