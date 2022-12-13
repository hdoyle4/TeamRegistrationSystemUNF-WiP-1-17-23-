using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Services
{
    public interface IAdminServices
    {
        Task<User[]> GetUsers();

        Task<bool> DeleteUserById(string id);

        Task<bool> EditUserByIdAsync(string id,EditUserViewModel user);
        Task<User?> GetUserByIdAsync(string id);
    }
}
