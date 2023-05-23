using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.Application.Services.Abstractions
{
    public interface IFileService
    {
        Task<Image> UploadImage(byte[] imageContent, string imageName, string entityTitle);
    }
}
