using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {   
        SiteProvider provider = new SiteProvider();
        public async Task<IActionResult> Index()
        {
            ViewBag.categories = await provider.Category.GetCategoriesAsync();
            return View();
        }
    }
}
