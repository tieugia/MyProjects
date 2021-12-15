using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard"), Authorize]
    [ServiceFilter(typeof(AccessFilter))]
    public class HomeController : Controller
    {
        //[Authorize(Roles = "Admin")]
        //SiteProvider provider;
        //public HomeController(IConfiguration configuration)
        //{
        //    provider = new SiteProvider(configuration);
        //}
        public IActionResult Index()
        {
            //ViewBag.accesses = provider.Access.GetAccessesByMemberId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View();
        }
    }
}
