using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PrizeController : Controller
    {
        PrizeRepository prizeRepository;
        public PrizeController(IConfiguration configuration)
        {
            prizeRepository = new PrizeRepository(configuration);
        }
        [HttpPost]
        public IActionResult Create(Prize obj)
        {
            int ret = prizeRepository.Add(obj);
            string[] msg = { "Failed", "Successfully" };
            TempData["msg"] = msg[ret];
            return Redirect("/prize");
        }
        public IActionResult Edit(byte id)
        {
            return View(prizeRepository.GetPrize(id));
        }
        [HttpPost]
        public IActionResult Edit(Prize obj)
        {
            int ret = prizeRepository.EditPrize(obj);
            string[] msg = { "Failed", "Successfully" };
            TempData["msg"] = msg[ret];
            return Redirect("/prize");
        }
        public IActionResult Delete(byte id)
        {
            int ret = prizeRepository.Delete(id);
            return Redirect("/prize");
        }
        public IActionResult Index()
        {
            return View(prizeRepository.GetPrizes());
        }
    }
}
