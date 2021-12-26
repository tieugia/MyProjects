using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
