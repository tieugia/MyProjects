using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        //provider.Category provider.Category;
        //public CategoryController(IConfiguration configuration)
        //{
        //    provider.Category = new provider.Category(configuration);
        //}
        SiteProvider provider;
        public CategoryController(SiteProvider provider)
        {
            this.provider = provider;
        }
        public IActionResult Edit(int id)
        {
            return View(provider.Category.GetCategory(id));
        }
        //Bat buoc phai dung Post
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            int ret = provider.Category.Edit(obj);
            string[] msg = { "Edit Failed", "Edit Successfully" };
            TempData["msg"] = msg[ret];
            return Redirect("/category");
        }
        public IActionResult Delete(int id)
        {
            int ret = provider.Category.Delete(id);
            string[] msg = { "Delete Failed", "Delete Successfully" };
            TempData["msg"] = msg[ret];
            return Redirect("/category");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            int ret = provider.Category.Add(obj);
            Console.WriteLine(ret);
            string[] msg = { "Create Failed", "Create Successfully" };
            TempData["msg"] = msg[ret];
            return Redirect("/category");
        }
        public IActionResult Index()
        {
            List<Category> list = provider.Category.GetCategories();
            return View(list);
            //hoac:
            //return View(provider.Category.GetCategories());
        }
    }
}
