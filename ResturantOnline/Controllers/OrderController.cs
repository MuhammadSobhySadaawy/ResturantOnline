using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantOnline.Models;
using ResturantOnline.Repositores;
using ResturantOnline.ViewModel;
using System.Security.Claims;

namespace ResturantOnline.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IItemRepository itemRepository;
        private readonly IOrder_ItemRepository order_ItemRepository;

        public OrderController(IOrderRepository orderRepository, IItemRepository itemRepository, IOrder_ItemRepository order_ItemRepository)
        {
            this.orderRepository = orderRepository;
            this.itemRepository = itemRepository;
            this.order_ItemRepository = order_ItemRepository;
        }



        public ActionResult Index()
        {

            return View(orderRepository.GetAll());
        }


        public ActionResult Details(int id)
        {
            return View();
        }



        public ActionResult Create()
        {
            CreateOrderViewModel viewModel = new CreateOrderViewModel();
            viewModel.Items = itemRepository.GetAll();
            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateOrderViewModel neworder)
        {
            decimal countTotal = 0;
            foreach (var item in neworder.Item_Id)
            {
                Item ditem = itemRepository.GetById(item);
                countTotal += ditem.Price;
            }



            string id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            Order order1 = new Order();
            order1.total = (int)countTotal;
            order1.Payment = neworder.Payment;
            order1.CachIn = orderRepository.Count() + order1.total;
            order1.Status = neworder.Status;
            order1.User_Id = id;
            order1.Change = order1.total - order1.Payment;

            orderRepository.Insert(order1);

            foreach (var itemid in neworder.Item_Id)
            {
                Order_Item order_Item = new Order_Item { Order_Id = order1.Id, Item_Id = itemid };
                order_ItemRepository.Insert(order_Item);

            }




            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Order order1 = orderRepository.GetById(id);


            return View(order1);
        }


        public ActionResult ShowItems(int order_id)
        {
            var orderItems = order_ItemRepository.GetAllByOrder(order_id);
            List<Item> items = new List<Item>();
            foreach (var item in orderItems)
            {
                Item i = itemRepository.GetById(item.Item_Id);
                items.Add(i);
            }


            return View(items);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Order order)
        {
            List<Order_Item> orderiteml = order_ItemRepository.GetAllByOrder(order.Id);

            foreach (var item in orderiteml)
            {
                order_ItemRepository.Delete(item.Id);
            }
            orderRepository.Delete(order.Id);



            return RedirectToAction("Index");

        }
    }
}
