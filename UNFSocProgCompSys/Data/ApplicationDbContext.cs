using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Competition> Competitions { get; set; }

        public DbSet<Team> Teams { get; set; } 
        public DbSet<User> Users { get; set; }
    }

}
