using System.ComponentModel.DataAnnotations;

namespace ResturantOnline.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
