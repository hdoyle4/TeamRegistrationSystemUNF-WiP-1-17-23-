using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNFSocProgCompSys.Data;
using UNFSocProgCompSys.Models;
using Microsoft.EntityFrameworkCore;
using UNFSocProgCompSys.Services;

namespace UNFSocProgCompSys.Services
{
    public class TeamServices : ITeamServices
    {
        private readonly ApplicationDbContext _context;

        public TeamServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TeamEntity[]> GetTeamsAsync()
        {
            return await _context.Teams
                .ToArrayAsync();
        }

        public async Task<bool> AddTeamAsync(TeamEntity newTeam)
        {
            newTeam.Id = Guid.NewGuid();

            _context.Teams.Add(newTeam);

            var saveSuccessful = await _context.SaveChangesAsync();
            return saveSuccessful == 1;
        }

    }
}
