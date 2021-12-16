using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Models;
using DAL.DTO;
using DAL.Interfaces;

namespace BusinessLogic.Converter
{
    public class PageConverter
    {
        private CommentConverter _CommentConverter = new CommentConverter();

        //Method overloading :)
        /// <summary>
        /// Takes values from PageModel and converts them equal to values from PageDTO.
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public PageDTO Convert_To_DTO_PageModel(PageModel pageModel)
        {
            return new PageDTO
            {
                ID = pageModel.ID,
                Title = pageModel.Title,
                Text = pageModel.Text,
                created_at = pageModel.created_at,
                updated_at = pageModel.updated_at,
            };
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the PageModel to a list with PageDTO. 
        /// </summary>
        /// <param name="pageModels"></param>
        /// <returns></returns>
        public List<PageDTO> Convert_To_DTO_PageModel(List<PageModel> pageModels)
        {
            return pageModels.Select(x => Convert_To_DTO_PageModel(x)).ToList();
        }

        /// <summary>
        /// Takes values from PageDTO and converts them equal to values from PageModel.
        /// </summary>
        /// <param name="dTO_PageModel"></param>
        /// <returns></returns>
        public PageModel Convert_To_PageModel(PageDTO dTO_PageModel)
        {
            var thisPageModel = new PageModel
            {
                ID = dTO_PageModel.ID,
                Title = dTO_PageModel.Title,
                Text = dTO_PageModel.Text,
                created_at = dTO_PageModel.created_at,
                updated_at = dTO_PageModel.updated_at,
            };
            if (dTO_PageModel.comments != null)
            {
                thisPageModel.comments = _CommentConverter.Convert_To_CommentModel(dTO_PageModel.comments);
            }
            return thisPageModel;
        }

        /// <summary>
        /// Using LINQ, this method converts a list with the PageDTO to a list with PageModel.
        /// </summary>
        /// <param name="dTO_PageModels"></param>
        /// <returns></returns>
        public List<PageModel> Convert_To_PageModel(List<PageDTO> dTO_PageModels)
        {
            return dTO_PageModels.Select(x => Convert_To_PageModel(x)).ToList();
        }

    }
}
