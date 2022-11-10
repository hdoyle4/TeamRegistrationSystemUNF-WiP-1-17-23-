using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UNFSocProgCompSys.Models;
using Microsoft.AspNetCore.Authorization;

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

        
        public IActionResult Login(string? returnUrl = null)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.ReturnUrl = returnUrl;
            return View(loginViewModel);
       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel LoginValues,string? returnUrl= null)
        {
            LoginValues.ReturnUrl = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(LoginValues.Username, LoginValues.Password, LoginValues.RememberMe,lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("Password", "Invalid Login attempt.");
            }
            else
            {
                return View(LoginValues);
            }
            return View(LoginValues);
        }

        public IActionResult Register(string returnUrl = null)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            registerViewModel.ReturnUrl = returnUrl;
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel, string? returnUrl = null)
        {
               
            registerViewModel.ReturnUrl = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/");
            if(ModelState.IsValid)
            {
                var regUser = new User { 
                    Email = registerViewModel.Email, 
                    UserName = registerViewModel.Username,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    School = registerViewModel.School,
                    Gender = registerViewModel.Gender,
                    ProgLang = registerViewModel.ProgLang,
                    ClassesTaken = registerViewModel.ClassesTaken,
                }; 
                var result = await _userManager.CreateAsync(regUser,registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(regUser, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                ModelState.AddModelError("Password", "User could not be created.Password not unique enough");
            } 
            return View(registerViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
