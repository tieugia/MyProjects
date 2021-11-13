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
        int size = 9;
        SiteProvider provider;
        public HomeController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public IActionResult Datatable()
        {
            List<Result> results = provider.Result.GetResults();
            ViewBag.patterns = provider.Pattern.GetPatterns();
            foreach (var item in results)
            {
                item.Numbers = provider.Number.GetNumbersByResult(item.Id).ToArray();
            }
            return View(results);
        }
        public IActionResult LazyLoad()
        {
            return LoadMore();
        }
        public IActionResult Index(int id = 1)
        {
            //Pagination
            //return View(provider.Result.GetResults());
            List<Result> list = provider.Result.GetResults(id, 3, out int count);
            //ViewBag.count = count;
            //ViewBag.n = Math.Ceiling(count / (double)size);
            foreach (var item in list)
            {
                item.Numbers = provider.Number.GetNumbersByResult(item.Id).ToArray();
            }
            ViewBag.n = (count - 1) / size + 1;
            ViewBag.patterns = provider.Pattern.GetPatterns();  
            return View(list);
        }
        public IActionResult LoadMore()
        {
            return Index(1);
        }
        public IActionResult GetPatterns()
        {
            return Json(provider.Pattern.GetPatterns());
        }
        public IActionResult GetResults(int id)
        {
            List<Result> list = provider.Result.GetResults(id, size);
            foreach (var item in list)
            {
                item.Numbers = provider.Number.GetNumbersByResult(item.Id).ToArray();
            }
            return Json(list);
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
