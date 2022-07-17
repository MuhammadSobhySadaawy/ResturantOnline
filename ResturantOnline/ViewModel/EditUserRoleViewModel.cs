using Microsoft.AspNetCore.Identity;

namespace ResturantOnline.ViewModel
{
    public class EditUserRoleViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string? RoleId { get; set; }
        public List<IdentityRole> RoleNames { get; set; }
    }
}
