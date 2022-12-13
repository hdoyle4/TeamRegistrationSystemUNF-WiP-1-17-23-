using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Services
{
    public interface IProfileServices
    {
        Task<User?> GetUserByNameAsync(string username);
        Task<bool> EditUserByIdAsync(string id, ProfileView ProfileViewEditedVals);
        Task<User?> GetUserByIdAsync(string id);
    }
}
