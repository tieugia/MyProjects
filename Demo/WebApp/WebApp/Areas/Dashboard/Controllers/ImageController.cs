using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebApp.Models;

namespace WebApp.Area.Dashboard.Controllers
{
    [Area("dashboard")]
    public class ImageController : Controller
    {
        SiteProvider provider;
        public ImageController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public IActionResult Index()
        {
            return View(provider.Image.GetImages());
        }
        [HttpPost]
        public IActionResult Create(IFormFile f)
        {
            if (f != null)
            {
                //phan mo rong tap tin
                string ext = Path.GetExtension(f.FileName);
                string imageUrl = Helper.RandomString(32 - ext.Length) + ext;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageUrl);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    f.CopyTo(stream);
                }
                Image image = new Image
                {
                    ImageOriginal = f.FileName,
                    ImageUrl = imageUrl,
                    ImageSize = f.Length,
                    ImageType = f.ContentType
                };
                provider.Image.Add(image);
                return Redirect("/dashboard/image");
            }
            return View();
        }
        public IActionResult Create() { return View(); }
    }
}
