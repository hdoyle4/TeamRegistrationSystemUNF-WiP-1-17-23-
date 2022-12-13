using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Services
{
    public interface ITeamServices
    {
        Task<TeamEntity[]> GetTeamsAsync();

        Task<bool> AddTeamAsync(TeamEntity newTeam);
    }
}
