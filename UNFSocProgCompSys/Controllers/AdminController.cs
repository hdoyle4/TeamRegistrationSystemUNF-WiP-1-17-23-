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
         
            var model = new ProfileView()
            {
                UserProfile = users
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
                return RedirectToAction("UserList1");
            }
            return View("UserList1");
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteUser(string id)
        //{
        //    var user = await userManager.FindByIdAsync(id);

        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
        //        return View("UserList");
        //    }
        //    else
        //    {
        //        var result = await userManager.DeleteAsync(user);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("UserList");
        //        }

        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }

        //        return View("UserList");
        //    }
        //}
    }
}
