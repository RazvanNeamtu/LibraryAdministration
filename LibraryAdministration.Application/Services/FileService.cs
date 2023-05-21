using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;

namespace LibraryAdministration.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IConfiguration _configuration;

        public FileService(IImageRepository imageRepository, IConfiguration configuration)
        {
            _imageRepository = imageRepository;
            _configuration = configuration;
        }

        public async Task<Image> UploadImage(byte[] imageContent, string imageName, string entityTitle)
        {
            var newImageName = ProcessImageName(imageName, entityTitle);
            var image = await _imageRepository.GetFirstOrDefault(img => img.Name == newImageName);
            if (image is null)
            {
                var imagePath = SaveImageToDisk(imageContent, newImageName);
                image = new Image { Name = newImageName, Path = imagePath, OriginalName = imageName };

                _imageRepository.Add(image);
            }
            return image;
        }

        private string SaveImageToDisk(byte[] bytes, string imageName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string absolutePath = Path.Combine(baseDirectory, _configuration["Files:ImagesPath"], imageName);
            string directory = Path.GetDirectoryName(absolutePath);
            Directory.CreateDirectory(directory);
            File.WriteAllBytes(absolutePath, bytes);

            string imagePath = Path.GetRelativePath(baseDirectory, absolutePath);
            return imagePath;
        }

        /// <summary>
        /// Replace the original image name with a new image name as {EntityName}{originalImageName} where both names will be trimmed
        /// </summary>
        /// <param name="originalImageName"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        private string ProcessImageName(string originalImageName, string entityName)
        {
            return $"{entityName.Replace(" ", string.Empty)}{originalImageName.Replace(" ", string.Empty)}";
        }
    }
}
