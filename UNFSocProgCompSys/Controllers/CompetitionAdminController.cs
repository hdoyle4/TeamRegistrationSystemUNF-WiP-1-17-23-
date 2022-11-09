using Microsoft.AspNetCore.Mvc;
using UNFSocProgCompSys.Data;
using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Controllers
{
    public class CompetitionAdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CompetitionAdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Page to view competition list and manage competitions (Admin)
        public IActionResult CompetitionManagement()
        {
            IEnumerable<Competition> CompetitionList = _db.Competitions;
            return View(CompetitionList);
        }
        //Page to create a new competition (Admin)
        public IActionResult CompetitionCreate()
        {
            return View();
        }
        //Page to edit an existing competition (Admin)
        public IActionResult CompetitionEdit(Guid? CompetitionID)
        {
            if (CompetitionID == null)
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
        } //End of CompetitionEdit
    }     //End of class CompetitionAdminController
}         //End of namespace UNFSocProgCompSys.Controllers
