using ResturantOnline.Models;
using System.ComponentModel.DataAnnotations;

namespace ResturantOnline.ViewModel
{
    public class ItemCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Titel { get; set; }



        [MaxLength(1000)]
        public string Description { get; set; }
        public decimal Price { get; set; }

        [Required]
        public bool Status { get; set; }
        public string? Photo { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        public IFormFile? Image { get; set; }
        public int Menu_Id { get; set; }
        public List<Menu> Menus { get; set; } = new List<Menu>();
    }
}
