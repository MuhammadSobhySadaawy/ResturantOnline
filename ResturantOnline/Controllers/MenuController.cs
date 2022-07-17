using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantOnline.Models;
using ResturantOnline.Repositores;
using ResturantOnline.ViewModel;

namespace ResturantOnline.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MenuController : Controller
    {
        private readonly IMenuRepository menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }




        public ActionResult Index()
        {
            return View(menuRepository.GetAll());
        }


        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Menu menu = menuRepository.GetById(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View("Details", menu);
        }


        public ActionResult Create()
        {
            return View(new MenuCreateViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuCreateViewModel menuvm)
        {
            bool IsNull = menuRepository.checkNull(menuvm);
            if (IsNull == false)
            {

                if (ModelState.IsValid == true)
                {
                    menuRepository.Insert(menuvm);
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "you should add photo");

            return View("Create", menuvm);

        }


        public ActionResult Edit(int id)
        {
            Menu menu = menuRepository.GetById(id);
            MenuCreateViewModel MenuVM = new MenuCreateViewModel();
            MenuVM.Id = id;
            MenuVM.Titel = menu.Titel;
            MenuVM.Type = menu.Type;
            MenuVM.Description = menu.Description;
            MenuVM.Status = menu.Status;
            // MenuVM.Photo = menu.Image;
            // image
            return View(MenuVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MenuCreateViewModel menuvm)
        {
            if (ModelState.IsValid == true)
            {

                menuRepository.Edit(id, menuvm);
                return RedirectToAction("Index");
            }
            return View("Edit", menuvm);

        }


        public ActionResult Delete(int id)
        {
            Menu menu = menuRepository.GetById(id);
            return View(menu);
        }

        public ActionResult ConfirmDelete(int id)
        {

            try
            {
                menuRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return Content("Can't Delete This Record Because Related Other Table");
            }

        }
    }
}
