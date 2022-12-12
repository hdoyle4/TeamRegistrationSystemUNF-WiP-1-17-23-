using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Services
{
    public interface IProfileServices
    {
        Task<User?> GetUserByNameAsync(string username);

        Task<int> EditUserByIdAsync(string id, ProfileView ProfileViewEditedVals);
    }
}
