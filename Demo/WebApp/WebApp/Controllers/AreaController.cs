using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AreaController : Controller
    {
        AreaRepository areaRepository;
        public AreaController(IConfiguration configuration)
        {
            areaRepository = new AreaRepository(configuration);
        }
        public IActionResult Index()
        {
            return View(areaRepository.GetAreas());
        }
    }
}
