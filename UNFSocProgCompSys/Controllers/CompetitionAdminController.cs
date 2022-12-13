using Microsoft.AspNetCore.Authorization;
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

        //Page to create a new competition (Admin), this is a GET action
        public IActionResult CompetitionCreate()
        {
            return View();
        }

        //POST action for page to create a new competition (Admin)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompetitionCreate(Competition NewCompetition)
        {
            if (ModelState.IsValid)
            {
                _db.Competitions.Add(NewCompetition);
                _db.SaveChanges();
                return RedirectToAction("CompetitionManagement");
            }
            else
            {
                return View(NewCompetition);
            }
        }

        //Page to edit an existing competition (Admin), this is a GET action
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
        }

        //POST action for page to edit an existing competition (Admin)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompetitionEdit(Competition ExistingCompetition)
        {
            if (ModelState.IsValid)
            {
                _db.Competitions.Update(ExistingCompetition);
                _db.SaveChanges();
                return RedirectToAction("CompetitionManagement");
            }
            else
            {
                return View(ExistingCompetition);
            }
        }

        //Page to remove an existing competition (Admin), this is a GET action
        public IActionResult CompetitionRemove(Guid? CompetitionID)
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
        }

        //POST action for page to remove an existing competition (Admin)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompetitionRemovePost(Guid? CompetitionID)
        {
            var ExistingCompetition = _db.Competitions.Find(CompetitionID);

            if (ExistingCompetition == null)
            {
                return NotFound();
            }
            else
            {
                _db.Competitions.Remove(ExistingCompetition);
                _db.SaveChanges();
                return RedirectToAction("CompetitionManagement");
            }
        }
    }     //End of class CompetitionAdminController
}         //End of namespace UNFSocProgCompSys.Controllers
