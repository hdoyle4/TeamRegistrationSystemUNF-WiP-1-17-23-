using Microsoft.AspNetCore.Mvc;
using UNFSocProgCompSys.Data;
using UNFSocProgCompSys.Services;
using UNFSocProgCompSys.Models;
using System;

namespace UNFSocProgCompSys.Controllers
{
    public class TeamController : Controller
    {

        private readonly ITeamServices _teamService;

        public TeamController(ITeamServices teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            //Get teams from the database
            //IEnumerable<Team> TeamList = _db.Teams;
            var teams = await _teamService.GetTeamsAsync();

            //Put Teams into a model
            var model = new TeamViewModel()
            {
                Teams = teams
            };
            //Render view using the model
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        //Creating a new Team and adding it to the database

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTeam(TeamEntity newTeam)
        {
            //Validate the entered team info
            if (!ModelState.IsValid)
            {
                return BadRequest("Could not add team.");
                //RedirectToAction("Create");
            }

            var successful = await _teamService.AddTeamAsync(newTeam);
            if (!successful)
            {
                return BadRequest("Could not add team.");
            }

            return RedirectToAction("Index");
        }
    }
}
