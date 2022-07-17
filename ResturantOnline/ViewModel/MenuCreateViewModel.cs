using System.ComponentModel.DataAnnotations;

namespace ResturantOnline.ViewModel
{
    public class MenuCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Titel { get; set; }

        [Required]
        [MaxLength(45)]
        public string Type { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public bool Status { get; set; }
        //  [Required]
        public string? Photo { get; set; }

        // [Required(ErrorMessage = "Please choose profile image")]
        // [RequiredIFormFile]
        public IFormFile? Image { get; set; }
    }
}
