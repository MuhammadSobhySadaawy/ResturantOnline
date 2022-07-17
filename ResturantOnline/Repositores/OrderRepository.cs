using Microsoft.EntityFrameworkCore;
using ResturantOnline.Models;

namespace ResturantOnline.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context context;

        public OrderRepository(Context context)
        {
            this.context = context;
        }
        public List<Order> GetAll()
        {
            return context.Orders.Include(a => a.ApplicationUser).ToList();
        }
        public Order GetById(int id)
        {
            return context.Orders.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
        public void Edit(int id, Order order)
        {
            Order oldOrder = GetById(id);
            oldOrder.total = order.total;
            oldOrder.CachIn = order.CachIn;
            oldOrder.Status = order.Status;
            oldOrder.Payment = order.Payment;
            oldOrder.Change = order.Change;
            oldOrder.User_Id = order.User_Id;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Order oldOrder = GetById(id);
            context.Orders.Remove(oldOrder);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Orders.Sum(e => e.total);
        }
    }
}
