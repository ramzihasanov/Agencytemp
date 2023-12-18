using Agency.Areas.ViewModels;
using Agency.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        private readonly SignInManager<AppUser> signInManager;
      

        public AccountController(UserManager<AppUser> userManager ,SignInManager<AppUser> signInManager)
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
        public async Task<IActionResult> Login(MemberLoginViewModel memberLoginView)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = null;

            user = await userManager.FindByNameAsync(memberLoginView.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "sifren sefdi ,zarafat edirerem adinda sef ola biler");
                return View();
            }

            var result = await signInManager.PasswordSignInAsync(user, memberLoginView.Password, false, false);

            if (result.Succeeded==false)
            {
                ModelState.AddModelError("", "sifren sefdi ,zarafat edirerem adinda sef ola biler");
                return View();
            }

            return RedirectToAction("index", "home");

        }
        public IActionResult Register()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterViewModel memberRegisterViewModel)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = null;
            appUser = await userManager.FindByNameAsync(memberRegisterViewModel.Username);
            if (appUser != null)
            {
                ModelState.AddModelError("Username", "bu adda adam var basqa ad tap");
                return View();
            }
            appUser = await userManager.FindByEmailAsync(memberRegisterViewModel.Email);
            if (appUser != null)
            {
                ModelState.AddModelError("Email", "bu emailde adam var basqa email tap");
                return View();
            }
            AppUser appUser1 = new AppUser()
            {
                FullName = memberRegisterViewModel.Fullname,
                UserName = memberRegisterViewModel.Username,
                Email = memberRegisterViewModel.Email
            };
            var result = await userManager.CreateAsync(appUser1, memberRegisterViewModel.Password);
            if (result.Succeeded==false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }
            await userManager.AddToRoleAsync(appUser1, "Member");
            await signInManager.SignInAsync(appUser1, isPersistent: false);
            return RedirectToAction("Index", "home");
        }



        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
