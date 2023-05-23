using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<UserInfo>
    {
        void Update(UserInfo user);
        Task Save();
        Task<UserInfo?> GetUserInfoByIdentityUserId(string identityUserId);
    }
}
