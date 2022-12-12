using UNFSocProgCompSys.Data;
using UNFSocProgCompSys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace UNFSocProgCompSys.Services
{
    public class ProfileServices : IProfileServices
    {   
        private readonly ApplicationDbContext _context;
     
        public ProfileServices(ApplicationDbContext context)
        {
            _context = context;
         
        }

        public async Task<User?> GetUserByNameAsync(string username)
        {
            
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {

           return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

       public async Task<int> EditUserByIdAsync(string id,ProfileView ProfileViewEditedVals)
        {
           
            var User=await GetUserByIdAsync(id);
            
            if (User == null)
            {
                return 0;
            }
            else
            {
                User.FirstName = ProfileViewEditedVals.FirstName;
                User.LastName = ProfileViewEditedVals.LastName;
                User.Email = ProfileViewEditedVals.Email;
                User.Gender = ProfileViewEditedVals.Gender;
                User.ClassesTaken = ProfileViewEditedVals.ClassesTaken;
                User.School = ProfileViewEditedVals.School;
                User.UserName = ProfileViewEditedVals.Username;
                User.ProgLang = ProfileViewEditedVals.ProgLang;
            }


            return await _context.SaveChangesAsync();
        }
     
    }
}
