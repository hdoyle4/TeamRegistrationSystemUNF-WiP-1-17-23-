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
        public async Task<User?> GetUserByIdAsync(string id)
        {

            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> EditUserByIdAsync(string id,EditUserViewModel user)
        {

            var User =await GetUserByIdAsync(id);

            if (User == null)
            {
                return false;
            }
            else
            {
             
                User.FirstName = user.FirstName;
                User.LastName = user.LastName;
                User.Email = user.Email;
                User.Gender = user.Gender;
                User.ClassesTaken = user.ClassesTaken;
                User.School = user.School;
                User.UserName = user.Username;
                User.NormalizedUserName = user.Username.ToUpper();
                User.ProgLang = user.ProgLang;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteUserById(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
           _context.Users.Remove(user);
           await _context.SaveChangesAsync();
           return true;
        }

    }
}
