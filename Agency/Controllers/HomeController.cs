
using Agency.Data.DAL;
using Agency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agency.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly AppDbContext context;

        public HomeController(AppDbContext context)
        {
           
            this.context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {categories=context.Categories.ToList(),
            portfolios=context.Portfolios.ToList(),

            };
            return View(homeViewModel);
        }

    
    }
}