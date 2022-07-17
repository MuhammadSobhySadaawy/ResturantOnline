using System.ComponentModel.DataAnnotations;

namespace ResturantOnline.ViewModel
{
    public class RegisterUserModelView
    {
        [MaxLength(12)]
        [Required]
        [Display(Name = "User Name ")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        [Compare("Password", ErrorMessage = "The confirmation Password does not match the Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation Password ")]
        public string ConfermPassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Compare("Email",ErrorMessage = "The confirmation email does not match the email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirmation email")]
        public string ConfermEmail { get; set; }
        [Required]
        public string Address { get; set; }

    }
}