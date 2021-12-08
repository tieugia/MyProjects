using Microsoft.AspNetCore.Authorization;
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
    [Area("dashboard"),Authorize]
    [ServiceFilter(typeof(AccessFilter))]
    public class HomeController : Controller
    {
        //SiteProvider provider;
        //public HomeController(IConfiguration configuration)
        //{
        //    provider = new SiteProvider(configuration);
        //}
        public IActionResult Index()
        {
            //chua tốt
            //ViewBag.accesses = provider.Access.GetAccessesByMemberId(User.FindFirstValue(ClaimTypes.NameIdentifier)); 
            return View();
        }
    }
}
