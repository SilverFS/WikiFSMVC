using BusinessLogic.Converter;
using BusinessLogic.Models;
using MvcCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcCore.Converters
{
    public class PageViewConverter
    {
        private CommentViewConverter _CommentViewConverter = new CommentViewConverter();



        //Method overloading :)
        /// <summary>
        /// Takes values from PageModel and converts them equal to values from PageViewModel.
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public PageViewModel Convert_To_PageViewModel(PageModel pageModel)
        {

            var pageViewModel = new PageViewModel
            {
                ID = pageModel.ID,
                Title = pageModel.Title,
                Text = pageModel.Text,
                created_at = pageModel.created_at,
                updated_at = pageModel.updated_at,
            };
            if (pageModel.comments != null)
            {
                pageViewModel.comments = _CommentViewConverter.Convert_To_CommentViewModel(pageModel.comments);
            }
            return pageViewModel;
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the PageModel to a list with PageViewModel. 
        /// </summary>
        /// <param name="pageModels"></param>
        /// <returns></returns>
        public List<PageViewModel> Convert_To_PageViewModel(List<PageModel> pageModels)
        {
            return pageModels.Select(x => Convert_To_PageViewModel(x)).ToList();
        }

        /// <summary>
        /// Takes values from PageViewModel and converts them equal to values from PageModel.
        /// </summary>
        /// <param name="pageView"></param>
        /// <returns></returns>
        public PageModel Convert_To_PageModel(PageViewModel pageView)
        {
            return new PageModel
            {
                ID = pageView.ID,
                Title = pageView.Title,
                Text = pageView.Text,
                created_at = pageView.created_at,
                updated_at = pageView.updated_at,
            };
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the PageViewModel to a list with PageModel.
        /// </summary>
        /// <param name="pageView"></param>
        /// <returns></returns>
        public List<PageModel> Convert_To_PageModel(List<PageViewModel> pageView)
        {
            return pageView.Select(x => Convert_To_PageModel(x)).ToList();
        }

    }
}
