using LibraryAdministration.Contracts.Requests.Books;
using System.ComponentModel.DataAnnotations;

namespace LibraryAdministration.API.CustomValidation
{
    public sealed class ImageNameRequiredWithDependencyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (InsertBookRequest)validationContext.ObjectInstance;

            if (model.ImageContent != null && string.IsNullOrWhiteSpace(model.ImageName))
            {
                return new ValidationResult("ImageName is required when ImageContent is provided.");
            }

            return ValidationResult.Success;
        }
    }
}
