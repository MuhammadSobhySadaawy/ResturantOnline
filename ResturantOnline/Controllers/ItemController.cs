using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantOnline.Models;
using ResturantOnline.Repositores;
using ResturantOnline.ViewModel;

namespace ResturantOnline.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ItemController : Controller
    {



        private readonly IItemRepository itemRepository;
        private readonly IMenuRepository menuRepository;

        public ItemController(IItemRepository itemRepository, IMenuRepository menuRepository)
        {
            this.itemRepository = itemRepository;
            this.menuRepository = menuRepository;
        }



        public IActionResult Index()
        {
            return View(itemRepository.GetAll());
        }



        public IActionResult Details(int id)
        {
            Item item = itemRepository.GetById(id);
            return View("Details", item);
        }



        public IActionResult Create()
        {
            ItemCreateViewModel viewModel = new ItemCreateViewModel();
            viewModel.Menus = menuRepository.GetAll();
            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemCreateViewModel itemVm)
        {

            if (ModelState.IsValid == true)
            {

                itemRepository.Insert(itemVm);
                return RedirectToAction("Index");
            }

            return View("Create", itemVm);

        }



        public IActionResult Edit(int id)
        {

            Item item = itemRepository.GetById(id);
            ItemCreateViewModel itemVm = new ItemCreateViewModel();
            itemVm.Id = id;
            itemVm.Titel = item.Titel;
            itemVm.Price = item.Price;
            itemVm.Description = item.Description;
            itemVm.Status = item.Status;
            itemVm.Photo = item.Image;
            itemVm.Menu_Id = item.Menu_Id;
            itemVm.Menus = menuRepository.GetAll();
            return View(itemVm);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ItemCreateViewModel item)
        {

            if (ModelState.IsValid == true)
            {
                itemRepository.Edit(id, item);
                return RedirectToAction("index");
            }
            return View("Edit", item);

        }



        public IActionResult Delete(int id)
        {
            Item item = itemRepository.GetById(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {

            itemRepository.Delete(id);
            return RedirectToAction("Index");


        }



    }
}
