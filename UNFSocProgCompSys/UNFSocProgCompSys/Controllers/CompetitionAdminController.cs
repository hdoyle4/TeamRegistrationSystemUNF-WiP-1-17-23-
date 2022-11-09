using Microsoft.AspNetCore.Mvc;
using UNFSocProgCompSys.Data;

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

        }
        //Page to create a new competition (Admin)
        public IActionResult CompetitionCreate()
        {

        }
        //Page to edit an existing competition (Admin)
        public IActionResult CompetitionEdit()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
