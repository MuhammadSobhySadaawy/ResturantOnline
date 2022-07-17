using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantOnline.Models
{
    public class Order_Item
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int Order_Id { get; set; }
        [ForeignKey("Item")]
        public int Item_Id { get; set; }


        public Order Order { get; set; }
        public Item Item { get; set; }

    }
}
