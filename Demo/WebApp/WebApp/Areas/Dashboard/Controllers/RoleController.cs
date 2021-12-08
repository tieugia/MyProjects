using Microsoft.AspNetCore.Mvc;
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
   
    public class RoleController :Controller
    {
        RoleRepository role;
        SiteProvider provider;
        public RoleController(IConfiguration configuration)
        {
            role = new RoleRepository(configuration);
            provider = new SiteProvider(configuration);
        }
        public IActionResult Index()
        {
            ViewBag.accesses = provider.Access.GetAccessesByMemberId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.roles = role.GetRoles();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Role obj)
        {
            role.Add(obj);
            return Redirect("/dashboard/role");
        }
    }
}
