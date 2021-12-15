using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    [ServiceFilter(typeof(AccessFilter))]
    public class AccessController : Controller
    {
        SiteProvider provider;
        public AccessController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);   
        }
        public IActionResult Index()
        {
            ViewBag.accesses = provider.Access.GetAccessesByMemberId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(provider.Access.GetAccesses());
        }
        public IActionResult Create()
        {
            ViewBag.accesses = provider.Access.GetAccessesByMemberId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.roles = new SelectList(provider.Role.GetRoles(), "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Access obj)
        {
            provider.Access.Add(obj);
            return Redirect("/dashboard/access");
        }
    }
}
