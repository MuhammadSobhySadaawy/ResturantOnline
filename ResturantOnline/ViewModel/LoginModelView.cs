using System.ComponentModel.DataAnnotations;

namespace ResturantOnline.ViewModel
{
    public class LoginModelView
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RemeberME { get; set; }
    }
}
