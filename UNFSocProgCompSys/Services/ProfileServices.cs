using UNFSocProgCompSys.Data;
using UNFSocProgCompSys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace UNFSocProgCompSys.Services
{
    public class ProfileServices : IProfileServices
    {   
        private readonly ApplicationDbContext _context;
     
        public ProfileServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User[]> GetProfile(string username)
        {
            return await _context.Users.Where(x => x.UserName == username).ToArrayAsync();
        }

     
    }
}
