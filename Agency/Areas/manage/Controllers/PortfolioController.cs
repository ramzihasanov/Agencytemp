using Microsoft.AspNetCore.Mvc;

namespace Agency.Areas.manage.Controllers
{
    [Area("Manage")]
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
