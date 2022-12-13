using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Services
{
    public interface IAdminServices
    {
        Task<User[]> GetUsers();

        Task<bool> DeleteUserById(string id);
    }
}
