using ResturantOnline.Models;

namespace ResturantOnline.Repositores
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        void Insert(Order item);
        void Edit(int id, Order item);
        void Delete(int id);
        int Count();
    }
}
