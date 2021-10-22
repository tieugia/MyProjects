using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string pattern = "<table><tr><td>Giải đặc biệt</td><td colspan=\"2\">{0}</td></tr><tr><td>Giải Nhất</td><td>{1}</td><td>{2}</td></tr></table>";
            string[] a = { "37162", "3326", "1468" };
            ViewBag.pattern = pattern;
            ViewBag.a = a;
            return View();
        }
    }
}
