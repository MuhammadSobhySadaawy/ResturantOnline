using ResturantOnline.Models;
using System.ComponentModel.DataAnnotations;

namespace ResturantOnline.ViewModel
{
    public class CreateOrderViewModel
    {

        public int Id { get; set; }
        public int? total { get; set; }
        [Required]
        public bool Status { get; set; }
        public decimal? CachIn { get; set; }
        [Required]
        public decimal Payment { get; set; }
        public decimal? Change { get; set; }
        public string? User_Id { get; set; }
        [Required]
        public int[] Item_Id { get; set; }
        public List<Item>? Items { get; set; } = new List<Item>();

    }
}
