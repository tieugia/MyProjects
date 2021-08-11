using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        private readonly Context _context;

        public UserController(Context context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult CreateYourAccount([Bind("Username,Password, Email")] User User)
        {
            if (ModelState.IsValid)
            {
                _context.Add(User);
                _context.SaveChanges();
                return RedirectToAction(nameof(Login));
            }
            return View(User);
        }

        [HttpPost]
        public ActionResult Login(User obj)
        {
            if (ModelState.IsValid)
            {
                var user = _context.User.FirstOrDefault(p => p.Username == obj.Username && p.Password == obj.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("username", user.Username);
                    HttpContext.Session.SetString("userId", user.UserID.ToString());
                    return RedirectToAction("Index", "Diaries");
                }
                else
                {
                    Console.WriteLine("Invalid Account");
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login");
        }
    }
}
