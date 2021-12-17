using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface ILogicPage
    {
        void Update(PageModel pageModel);
        void Delete(int ID);
    }
}
