using System.Collections.Generic;

namespace MvcCore.Models
{
    public class IndexPageViewModel
    {
        public List<PageViewModel> pages { get; set; }
        public List<CommentViewModel> comments { get; set; }
    }
}
