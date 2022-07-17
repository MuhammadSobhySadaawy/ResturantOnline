using ResturantOnline.Models;
using ResturantOnline.Repositores;
using System.ComponentModel.DataAnnotations;

namespace ResturantOnline.ViewModel
{
    public class RequiredIFormFile : ValidationAttribute
    {

        private readonly IMenuRepository menuRepository;
        public RequiredIFormFile() : this(new MenuRepository(new Context()))
        {

        }



        public RequiredIFormFile(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            string newName = value.ToString();

            Menu stddb = menuRepository.GetByName(newName);

            MenuCreateViewModel crs = (MenuCreateViewModel)validationContext.ObjectInstance;

            if (stddb != null && stddb.Id != crs.Id)
            {
                return new ValidationResult("Please choose profile image");
            }

            return ValidationResult.Success;
        }
    }
}
