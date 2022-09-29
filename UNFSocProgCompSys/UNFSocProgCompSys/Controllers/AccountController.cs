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

       
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(LoginViewModel LoginValues)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(LoginValues.Email, LoginValues.Password, LoginViewModel);
        //    }

        //}

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
        {
       
            if(ModelState.IsValid)
            {
                var regUser = new User { Email = registerViewModel.Email, UserName = registerViewModel.Username }; 
                var result = await _userManager.CreateAsync(regUser,registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(regUser, isPersistent: false);
                    return LocalRedirect("/Home");
                }
                ModelState.AddModelError("Password", "User could not be created.Password not unique enough");
            } 
            return View(registerViewModel);
        }
 
    }
}
