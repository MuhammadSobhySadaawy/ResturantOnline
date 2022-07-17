using ResturantOnline.Models;
using ResturantOnline.ViewModel;

namespace ResturantOnline.Repositores
{
    public class MenuRepository : IMenuRepository
    {
        private readonly Context context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MenuRepository(Context context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public MenuRepository(Context context)
        {
            this.context = context;

        }

        public List<Menu> GetAll()
        {
            return context.Menus.ToList();
        }
        public Menu GetById(int id)
        {
            return context.Menus.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(MenuCreateViewModel menuvm)
        {
            string stringFileName = UploadFile(menuvm);

            Menu menu = new Menu
            {
                Titel = menuvm.Titel,
                Type = menuvm.Type,
                Description = menuvm.Description,
                Status = menuvm.Status,
                Image = stringFileName,
            };
            context.Menus.Add(menu);
            context.SaveChanges();
        }
        private string UploadFile(MenuCreateViewModel menuvm)
        {
            string fileName = null;
            if (menuvm.Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");

                fileName = Guid.NewGuid().ToString() + "_" + menuvm.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    menuvm.Image.CopyTo(fileStream);
                    fileStream.Close();
                }
            }
            return fileName;

        }
        public void Edit(int id, MenuCreateViewModel menuvm)
        {
            string stringFileName = UploadFile(menuvm);
            Menu oldMenu = GetById(id);
            oldMenu.Titel = menuvm.Titel;
            oldMenu.Type = menuvm.Type;
            oldMenu.Description = menuvm.Description;
            oldMenu.Status = menuvm.Status;
            //if (menuvm.Image != null)
            //{
            //    if (menuvm.Photo != null)
            //    {
            //        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", menuvm.Photo);
            //        System.IO.File.Delete(filePath);
            //    }

            //   
            //}
            oldMenu.Image = (stringFileName == null) ? oldMenu.Image : stringFileName;

            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Menu oldMenu = GetById(id);
            context.Menus.Remove(oldMenu);
            context.SaveChanges();
        }

        public Menu GetByName(string titel)
        {
            return context.Menus.FirstOrDefault(e => e.Titel == titel);
        }

        public bool checkNull(MenuCreateViewModel menuvm)
        {
            if (menuvm.Image == null)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
