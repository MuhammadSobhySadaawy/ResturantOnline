using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantOnline.Models
{
    public class Item
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Titel { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public bool Status { get; set; }
        [MaxLength(255)]
        public string Image { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Menu")]
        public int Menu_Id { get; set; }

        public Menu Menu { get; set; }

    }
}
