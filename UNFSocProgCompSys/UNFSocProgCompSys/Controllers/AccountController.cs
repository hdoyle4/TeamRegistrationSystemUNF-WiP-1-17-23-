using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UNFSocProgCompSys.Models;

namespace UNFSocProgCompSys.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel, string returnUrl)
        {
            registerViewModel.ReturnUrl = returnUrl;
            if(returnUrl == null)
            {
                returnUrl = Url.Content("Home");
            }
            if(ModelState.IsValid)
            {
                var regUser = new User { Email = registerViewModel.Email, UserName = registerViewModel.Username }; 
                var result = await _userManager.CreateAsync(regUser,registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(regUser, isPersistent: false);
                }
                ModelState.AddModelError("Password", "User could not be created.Password not unique enough");
            } 
            return View(registerViewModel);
        }
        public async Task<ActionResult> Register(string returnUrl=null)
        {
            RegisterViewModel registeredViewModel = new RegisterViewModel();
            registeredViewModel.ReturnUrl = returnUrl;
            return View(registeredViewModel);
        }
    }
}
