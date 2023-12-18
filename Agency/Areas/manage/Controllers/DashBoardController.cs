using Agency.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Areas.manage.Controllers
{
    [Area("manage")]
     [Authorize(Roles ="Admin")]
    public class DashBoardController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> role;

        public DashBoardController(UserManager<AppUser> userManager, RoleManager<IdentityRole> role)
        {
            this.userManager = userManager;
            this.role = role;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser appUser = new AppUser()
            {
                FullName = "Remzi hesenov",
                UserName = "Ramzes"
            };

            var result = await userManager.CreateAsync(appUser, "Remzi123@");

            return Ok(result);
        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role1 = new IdentityRole("Admin");
            IdentityRole role2 = new IdentityRole("Member");


            await role.CreateAsync(role1);
            await role.CreateAsync(role2);

            return Ok();



        }
        public async Task<IActionResult> AddRoleAdmin()
        {
            var appUser = await userManager.FindByNameAsync("Ramzes");
           var result= await userManager.AddToRoleAsync(appUser, "Admin");

            return Ok(result);



        }
    }
}
