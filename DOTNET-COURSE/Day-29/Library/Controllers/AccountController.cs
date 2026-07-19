using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _SignInManger;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._SignInManger= signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUserVM model)
        {

            ApplicationUser user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Address = model.Address
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM model)
        {
            var result = await _userManager.FindByNameAsync(model.UserName);

            if (result != null)
            {
                var signInResult = await _userManager.CheckPasswordAsync(result, model.Password);

                if (signInResult)
                {
                    await _SignInManger.SignInAsync(result, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user name or password");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user name or password");
            }

            return View();


        }


        public async Task<IActionResult> Logout()
        {
            await _SignInManger.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
