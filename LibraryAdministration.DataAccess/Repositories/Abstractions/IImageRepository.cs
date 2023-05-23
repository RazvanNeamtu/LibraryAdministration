using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IImageRepository : IRepository<Image>
    {
        void Update(Image image);
        Task Save();
    }
}
