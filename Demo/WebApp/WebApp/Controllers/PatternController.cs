using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PatternController : Controller
    {
        PatternRepository patternRepository;
        public PatternController(IConfiguration configuration)
        {
            patternRepository = new PatternRepository(configuration);
        }
        public IActionResult Index()
        {
            return View(patternRepository.GetPatterns());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pattern obj)
        {
            int ret = patternRepository.Add(obj);
            return Redirect("/pattern");
        }
        public IActionResult Edit(byte id)
        {
            return View(patternRepository.GetPatternById(id));  
        }
        [HttpPost]
        public IActionResult Edit(Pattern obj)
        {
            patternRepository.Edit(obj);
            return Redirect("/pattern");
        }
        public IActionResult Delete(byte id)
        {
            patternRepository.Delete(id);
            return Redirect("/pattern");
        }
    }
}
