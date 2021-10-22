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
        NumberRepository numberRepository;
        public NumberController(IConfiguration configuration)
        {
            numberRepository = new NumberRepository(configuration);
        }
        public IActionResult Index()
        {
            return View(numberRepository.GetNumbers(1));
        }
    }
}
