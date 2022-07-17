using ResturantOnline.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantOnline.Models
{
    public class Order
    {

        public int Id { get; set; }
        public int total { get; set; }
        public bool Status { get; set; }

        public decimal CachIn { get; set; }
        public decimal Payment { get; set; }
        public decimal Change { get; set; }

        [ForeignKey("ApplicationUser")]
        public string User_Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}
