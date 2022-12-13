using Microsoft.AspNetCore.Identity;
using UNFSocProgCompSys.Models;
using UNFSocProgCompSys.Services;
using Microsoft.AspNetCore.Mvc;

namespace UNFSocProgCompSys.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminServices _AdminService;
        public AdminController(IAdminServices adminServices)
        {
            _AdminService = adminServices;
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var users = await _AdminService.GetUsers();
         
            var model = new EditUserViewModel()
            {
                Users = users
            };
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var success = await _AdminService.DeleteUserById(id);
            if (success)
            {
                return RedirectToAction("UserList");
            }
            return View("UserList");
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = new EditUserViewModel();
            var UserProfileVals = await _AdminService.GetUserByIdAsync(id);
            
            user.FirstName = UserProfileVals.FirstName;
            user.LastName = UserProfileVals.LastName;
            user.Email = UserProfileVals.Email;
            user.Gender = UserProfileVals.Gender;
            user.ClassesTaken = UserProfileVals.ClassesTaken;
            user.School = UserProfileVals.School;
            user.Username = UserProfileVals.UserName;
            user.ProgLang = UserProfileVals.ProgLang;

            return View(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditUser(string id,EditUserViewModel userEdit)
        {

            var resultOfEdit = await _AdminService.EditUserByIdAsync(id,userEdit);

            if (resultOfEdit == false)
            {
                return BadRequest("Edit of user profile has failed!");
            }
            return RedirectToAction("UserList");
        }

    }
}
