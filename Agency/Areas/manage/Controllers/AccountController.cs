using Agency.Areas.ViewModels;
using Agency.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Areas.manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginViewModel)
        {
            if (!ModelState.IsValid) return View(adminLoginViewModel);
            AppUser appUser = null;
            appUser = await userManager.FindByNameAsync(adminLoginViewModel.Username);
            if (appUser == null)
            {
                ModelState.AddModelError("", "ya sifren sefdi yada adin ");
                return View();
            }
            var result = await signInManager.PasswordSignInAsync(appUser, adminLoginViewModel.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "ya sifren sefdi yada adin");
                return View();
            }

            return RedirectToAction("Index", "DashBoard");
        }
    }
}
