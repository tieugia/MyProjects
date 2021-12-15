using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class WelcomeController: Controller
    {
        //methods
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Hi()
        {
            return View();
        }
    }
}
