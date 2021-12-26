using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class CategoryController : Controller
    {
        SiteProvider provider = new SiteProvider();
        public async Task<IActionResult> Delete(byte id)
        {
            await provider.Category.Delete(id);
            return Redirect("/dashboard/category");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category obj)
        {
            await provider.Category.Add(obj);
            return Redirect("/dashboard/category");
        }
        public async Task<IActionResult> Index()
        {
            return View(await provider.Category.GetCategoriesAsync());
        }
    }
}
