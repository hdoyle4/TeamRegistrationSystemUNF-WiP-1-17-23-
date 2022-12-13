using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UNFSocProgCompSys.Data;
using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Controllers
{
    [Authorize]
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
        public IActionResult CompetitionHome(Guid? CompetitionID)
        {
            if(CompetitionID == null)
            {
                return NotFound();
            }
            else
            {
                var CurrentCompetition = _db.Competitions.Find(CompetitionID);

                if (CurrentCompetition == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(CurrentCompetition);
                }
            }
        }//End of Competition Home
    }    // End of class CompetitionController
}        // End of namespace UNFSocProgCompSys.Controllers
