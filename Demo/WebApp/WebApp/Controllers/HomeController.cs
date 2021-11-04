using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        SiteProvider provider;
        public HomeController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public IActionResult Index(int id =1)
        {
            //Pagination
            //return View(provider.Result.GetResults());
            List<Result> list = provider.Result.GetResults(id, 3, out int count);
            ViewBag.count = count;
            return View(list);
        }
        //public IActionResult Index()
        //{
        //    string pattern = "<table><tr><td>Giải đặc biệt</td><td colspan=\"2\">{0}</td></tr><tr><td>Giải Nhất</td><td>{1}</td><td>{2}</td></tr></table>";
        //    string[] a = { "37162", "3326", "1468" };
        //    ViewBag.pattern = pattern;
        //    ViewBag.a = a;
        //    return View();
        //}
    }
}
