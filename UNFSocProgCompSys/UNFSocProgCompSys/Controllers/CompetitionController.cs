using Microsoft.AspNetCore.Mvc;
using UNFSocProgCompSys.Data;
using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CompetitionController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Page to sign up for a competition from a list of competitions
        public IActionResult CompetitionSignUp()
        {
            IEnumerable<Competition> CompetitionList = _db.Competitions;
            return View(CompetitionList);
        }

        //Page to view actions relating to a competition
        public IActionResult CompetitionHome()
        {
            return View();
        }
    }   // End of class CompetitionController
}       // End of namespace UNFSocProgCompSys.Controllers
