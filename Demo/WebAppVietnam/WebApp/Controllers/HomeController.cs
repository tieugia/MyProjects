using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ServiceFilter(typeof(AccessFilter))]
    public class HomeController : Controller
    {
        ProvinceRepository province;
        DistrictRepository district;
        WardRepository ward;
        public HomeController(IConfiguration configuration)
        {
            province = new ProvinceRepository(configuration);
            district = new DistrictRepository(configuration);
            ward = new WardRepository(configuration);
        }
        public IActionResult Index()
        {
            ViewBag.provinces = new SelectList(province.GetProvinces(), "ProvinceId", "ProvinceName");
            return View();
        }
        public IActionResult Districts(string id)
        {
            return Json(district.GetDistricts(id));
        }
        public IActionResult Wards(string id)
        {
            return Json(ward.GetWards(id));
        }
    }
}