using LibraryAdministration.Contracts.Requests.Books;
using System.ComponentModel.DataAnnotations;

namespace LibraryAdministration.Contracts.CustomValidation
{
    internal class ImageContentRequiredWithDependency : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (InsertBookRequest)validationContext.ObjectInstance;

            if (!string.IsNullOrWhiteSpace(model.ImageName) && model.ImageContent == null)
            {
                return new ValidationResult("ImageName is required when ImageContent is provided.");
            }

            return ValidationResult.Success;
        }
    }
}
