using ResturantOnline.Models;

namespace ResturantOnline.Repositores
{
    public interface IOrder_ItemRepository
    {
        List<Order_Item> GetAll();
        Order_Item GetById(int id);
        void Insert(Order_Item item);
        void Edit(int id, Order_Item item);
        void Delete(int id);
        List<Order_Item> GetAllByOrder(int id);
    }
}
