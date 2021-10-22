using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProvinceController : Controller
    {
        ProvinceRepository provinceRepository;
        AreaRepository areaRepository;
        PatternRepository patternRepository;
        public ProvinceController(IConfiguration configuration)
        {
            provinceRepository = new ProvinceRepository(configuration);
            //khuyet diem
            areaRepository = new AreaRepository(configuration);
            patternRepository = new PatternRepository(configuration);
        }
        public IActionResult Index()
        {
            return View(provinceRepository.GetProvinces());
        }
        public IActionResult Create()
        {
            ViewBag.patterns = patternRepository.GetPatterns();
            return View(areaRepository.GetAreas());
        }
        [HttpPost]
        public IActionResult Create(Province obj)
        {
            int ret = provinceRepository.Add(obj);
            string[] msg = { "Failed", "Successfully" };
            TempData["msg"] = msg[ret];
            return Redirect("/province");
        }
        public IActionResult Edit(short id)
        {
            ViewBag.areas = areaRepository.GetAreas();
            return View(provinceRepository.GetProvince(id));
        }
        [HttpPost]
        public IActionResult Edit(Province obj)
        {
            int ret = provinceRepository.Edit(obj);
            string[] msg = { "Failed", "Successfully" };
            TempData["msg"] = msg[ret];
            return Redirect("/province");
        }
    }
}
