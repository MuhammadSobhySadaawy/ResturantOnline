using System.ComponentModel.DataAnnotations;

namespace ResturantOnline.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Titel { get; set; }
        [MaxLength(45)]
        public string Type { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public bool Status { get; set; }

        [Required]
        public string Image { get; set; }

    }
}
