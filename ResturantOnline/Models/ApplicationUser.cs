using Microsoft.AspNetCore.Identity;

namespace ResturantOnline.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
