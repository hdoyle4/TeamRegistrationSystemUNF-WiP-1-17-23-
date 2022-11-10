using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Services
{
    public interface IProfileServices
    {
        Task<User[]> GetProfile(string username);
    }
}
