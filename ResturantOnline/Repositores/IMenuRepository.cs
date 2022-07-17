using ResturantOnline.Models;
using ResturantOnline.ViewModel;

namespace ResturantOnline.Repositores
{
    public interface IMenuRepository
    {
        List<Menu> GetAll();
        Menu GetById(int id);
        Menu GetByName(string titel);
        void Insert(MenuCreateViewModel itemvm);
        void Edit(int id, MenuCreateViewModel itemvm);
        void Delete(int id);
        bool checkNull(MenuCreateViewModel menuvm);
    }
}
