using Microsoft.AspNetCore.Mvc;

namespace Agency.Areas.manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
