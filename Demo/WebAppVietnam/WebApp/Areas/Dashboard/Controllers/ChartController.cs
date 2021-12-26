using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class ChartController : Controller
    {
        SiteProvider provider;
        public ChartController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public IActionResult Index()
        {
            return View(provider.District.StatisticDistricts());
        }
        public IActionResult Pie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PieJson()
        {
            return Json(provider.District.StatisticDistricts());
        }
        public IActionResult Regression()
        {
            IEnumerable<SalesRestaurant> list = provider.Sales.GetSalesRestaurants(out double slope, out double intercept);
            ViewBag.slope = slope;
            ViewBag.intercept = intercept;
            return View(list);
        }
        public IActionResult Bar()
        {
            return View(provider.SalesRecord.GetSalesRecords());
        }
    }
}
