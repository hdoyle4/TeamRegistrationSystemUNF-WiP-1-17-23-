using Microsoft.AspNetCore.Mvc;
using UNFSocProgCompSys.Models;
using UNFSocProgCompSys.Services;
using Microsoft.AspNetCore.Authorization;

namespace UNFSocProgCompSys.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileServices _ProfileServices;
        public ProfileController(IProfileServices ProfileServices)
        {
            _ProfileServices = ProfileServices;
        }

        public async Task<IActionResult> ViewProfile()
        {
            var UserId = User?.Claims.FirstOrDefault()?.Value;
            var ProfileViewModel = new ProfileView();
            var UserProfileVals = await _ProfileServices.GetUserByIdAsync(UserId);
            
            ProfileViewModel.FirstName = UserProfileVals.FirstName;
            ProfileViewModel.LastName = UserProfileVals.LastName;
            ProfileViewModel.Email = UserProfileVals.Email;
            ProfileViewModel.Gender = UserProfileVals.Gender;
            ProfileViewModel.ClassesTaken = UserProfileVals.ClassesTaken;
            ProfileViewModel.School = UserProfileVals.School;
            ProfileViewModel.Username = UserProfileVals.UserName;
            ProfileViewModel.ProgLang = UserProfileVals.ProgLang;
            
            return View(ProfileViewModel);
        }

        public async Task<IActionResult>EditProfile()
        {
            string? UserName = User?.Identity?.Name;
            var ProfileViewModel= new ProfileView();
            var UserProfileVals = await _ProfileServices.GetUserByNameAsync(UserName);

            ProfileViewModel.FirstName = UserProfileVals.FirstName;
            ProfileViewModel.LastName = UserProfileVals.LastName;
            ProfileViewModel.Email = UserProfileVals.Email;
            ProfileViewModel.Gender = UserProfileVals.Gender;
            ProfileViewModel.ClassesTaken = UserProfileVals.ClassesTaken;
            ProfileViewModel.School = UserProfileVals.School;
            ProfileViewModel.Username = UserProfileVals.UserName;
            ProfileViewModel.ProgLang = UserProfileVals.ProgLang;

            return View(ProfileViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileView ProfileValues)
        {
            //string UserName=User?.Identity?.Name;
            //var UserId = User?.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var UserId = User?.Claims.FirstOrDefault()?.Value;

            if(UserId == null)
            {
                return BadRequest("UserId could not be retrieved");
            }
            
            var resultOfEdit =  await _ProfileServices.EditUserByIdAsync(UserId,ProfileValues);
            
            if(resultOfEdit == false)
            {
                return BadRequest("Edit of user profile has failed!");
            }
            return RedirectToAction("ViewProfile");
        }

     }

  }
    

