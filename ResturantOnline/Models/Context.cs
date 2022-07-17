using ResturantOnline.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ResturantOnline.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context() : base()
        {

        }
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Item> Order_Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6JLP6GK;Initial Catalog=Resturant;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
