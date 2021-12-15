using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    [ServiceFilter(typeof(AccessFilter))]
    public class RoleController : Controller
    {
        SiteProvider provider;
        public RoleController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public IActionResult Index()
        {
            ViewBag.roles = provider.Role.GetRoles();
            //ViewBag.accesses = provider.Access.GetAccessesByMemberId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View();
        }
        [HttpPost]
        public IActionResult Add(Role obj)
        {
            provider.Role.Add(obj);
            return Redirect("/dashboard/role");
        }
    }
}
