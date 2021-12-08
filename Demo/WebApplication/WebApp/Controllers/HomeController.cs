using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
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
        [HttpPost]
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
