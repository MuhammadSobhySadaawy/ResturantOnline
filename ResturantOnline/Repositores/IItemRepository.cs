using ResturantOnline.Models;
using ResturantOnline.ViewModel;

namespace ResturantOnline.Repositores
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item GetById(int id);
        void Insert(ItemCreateViewModel item);
        void Edit(int id, ItemCreateViewModel item);
        void Delete(int id);
    }
}
