using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantOnline.Models;
using ResturantOnline.Repositores;

namespace ResturantOnline.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Order_ItemController : Controller
    {
        private readonly IOrder_ItemRepository order_ItemRepository;

        public Order_ItemController(IOrder_ItemRepository order_ItemRepository)
        {
            this.order_ItemRepository = order_ItemRepository;
        }



        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order_Item order_Item)
        {

            return View();

        }


        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {

            return View();

        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {

            return View();

        }
    }
}
