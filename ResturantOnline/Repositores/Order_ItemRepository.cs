using ResturantOnline.Models;

namespace ResturantOnline.Repositores
{
    public class Order_ItemRepository : IOrder_ItemRepository
    {
        private readonly Context context;

        public Order_ItemRepository(Context context)
        {
            this.context = context;
        }
        public List<Order_Item> GetAll()
        {
            return context.Order_Items.ToList();
        }
        public Order_Item GetById(int id)
        {
            return context.Order_Items.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Order_Item order_Item)
        {
            context.Order_Items.Add(order_Item);
            context.SaveChanges();
        }
        public void Edit(int id, Order_Item order_Item)
        {
            Order_Item oldOrder_Item = GetById(id);
            oldOrder_Item.Order_Id = order_Item.Order_Id;
            oldOrder_Item.Item_Id = order_Item.Item_Id;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Order_Item oldOrder_Item = GetById(id);
            context.Order_Items.Remove(oldOrder_Item);
            context.SaveChanges();
        }

        public List<Order_Item> GetAllByOrder(int id)
        {
            return context.Order_Items.Where(e => e.Order_Id == id).ToList();
        }


    }
}
