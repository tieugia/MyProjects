using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class NumberController : Controller
    {
        //NumberRepository numberRepository;
        SiteProvider provider;
        //public NumberController(IConfiguration configuration)
        //{
        //    numberRepository = new NumberRepository(configuration);
        //}
        public NumberController(SiteProvider provider)
        {
            this.provider = provider;
        }
        public IActionResult Index()
        {
            return View(provider.Number.GetNumbers(1));
        }
        [HttpPost]
        public IActionResult Edit(Number obj)
        {
            //return Json(obj);
            return Json(provider.Number.Edit(obj));
        }
    }
}
