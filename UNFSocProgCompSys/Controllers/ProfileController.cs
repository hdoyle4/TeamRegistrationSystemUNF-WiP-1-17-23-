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
            string? user = User?.Identity?.Name;
            var model = new ProfileView();
            var UserProfile = await _ProfileServices.GetProfile(user);

           foreach (var UserAtr in UserProfile) {
                model.FirstName=UserAtr.FirstName;
                model.LastName=UserAtr.LastName;
                model.Email=UserAtr.Email;
                model.Gender=UserAtr.Gender;
                model.ClassesTaken=UserAtr.ClassesTaken;
                model.School=UserAtr.School;
                model.Username = UserAtr.UserName;
                model.ProgLang=UserAtr.ProgLang;
                model.Password = UserAtr.PasswordHash;
            }

          return View(model);
        }

        public async Task<IActionResult>EditProfile()
        {
            string? user = User?.Identity?.Name;
            var model= new ProfileView();
            var UserProfile = await _ProfileServices.GetProfile(user);
           
            foreach (var UserAtr in UserProfile)
            {
                model.FirstName = UserAtr.FirstName;
                model.LastName = UserAtr.LastName;
                model.Email = UserAtr.Email;
                model.Gender = UserAtr.Gender;
                model.ClassesTaken = UserAtr.ClassesTaken;
                model.School = UserAtr.School;
                model.Username = UserAtr.UserName;
                model.ProgLang = UserAtr.ProgLang;
                model.Password = UserAtr.PasswordHash;
            }

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileView ProfileValues)
        {
            return View(ProfileValues);
        }

     }

  }
    

