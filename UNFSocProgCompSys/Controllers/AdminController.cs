using Microsoft.AspNetCore.Mvc;

namespace UNFSocProgCompSys.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
