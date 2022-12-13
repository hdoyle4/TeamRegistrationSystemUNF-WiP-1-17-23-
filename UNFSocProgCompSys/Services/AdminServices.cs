using UNFSocProgCompSys.Data;
using UNFSocProgCompSys.Models;
using Microsoft.EntityFrameworkCore;

namespace UNFSocProgCompSys.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly ApplicationDbContext _context;

        public AdminServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User[]> GetUsers()
        {
            return await _context.Users.Where(x => x.UserName != null).ToArrayAsync();
            
        }

        public async Task<bool> DeleteUserById(string id)
        {
           var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
           _context.Users.Remove(user);
           _context.SaveChangesAsync();
            return true;
        }

    }
}
