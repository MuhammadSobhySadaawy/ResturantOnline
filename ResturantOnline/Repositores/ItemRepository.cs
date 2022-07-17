using Microsoft.EntityFrameworkCore;
using ResturantOnline.Models;
using ResturantOnline.ViewModel;

namespace ResturantOnline.Repositores
{
    public class ItemRepository : IItemRepository
    {

        private readonly Context context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ItemRepository(Context context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public List<Item> GetAll()
        {
            return context.Items.Include(e => e.Menu).ToList();
        }
        public Item GetById(int id)
        {
            return context.Items.FirstOrDefault(x => x.Id == id);
        }



        public void Insert(ItemCreateViewModel itemVm)
        {
            string stringFileName = UploadFile(itemVm);

            Item item = new Item
            {
                Titel = itemVm.Titel,
                Price = itemVm.Price,
                Description = itemVm.Description,
                Status = itemVm.Status,
                Image = stringFileName,
                Menu_Id = itemVm.Menu_Id,
            };
            context.Items.Add(item);
            context.SaveChanges();
        }

        public void Edit(int id, ItemCreateViewModel item)
        {
            string stringFileName = UploadFile(item);
            Item oldItem = GetById(id);
            oldItem.Titel = item.Titel;
            oldItem.Price = item.Price;
            oldItem.Description = item.Description;
            oldItem.Status = item.Status;
            oldItem.Image = stringFileName;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Item oldItem = GetById(id);
            context.Items.Remove(oldItem);
            context.SaveChanges();
        }
        private string UploadFile(ItemCreateViewModel itemuvm)
        {
            string fileName = null;
            if (itemuvm.Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");

                fileName = Guid.NewGuid().ToString() + "_" + itemuvm.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    itemuvm.Image.CopyTo(fileStream);
                    fileStream.Close();
                }
            }
            return fileName;


        }
    }
}
