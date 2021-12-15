using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using WebApp.Models;

namespace WebApp.Area.Dashboard.Controllers
{
    [Area("dashboard")]
    [ServiceFilter(typeof(AccessFilter))]
    public class ImageController : Controller
    {
        SiteProvider provider;
        public ImageController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        /*string Root
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            }
        }*/
        string Root => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        public IActionResult Webcam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Webcam(string data, string name)
        {
            byte[] bytes = Convert.FromBase64String(data);
            string url = Helper.RandomString(28) + ".png";
            using (Stream stream = new FileStream(Path.Combine(Root, url), FileMode.Create))
            {
                stream.Write(bytes);
            }
            Image image = new Image
            {
                ImageOriginal = name,
                ImageSize = bytes.Length,
                ImageType = "image/png",
                ImageUrl = url
            };
            return Json(provider.Image.Add(image));
        }
        public IActionResult DragAndDrop()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AjaxMultiple(IFormFile[] af)
        {
            int ret = 0;
            foreach (var f in af)
            {
                Image image = Save(f);
                ret += provider.Image.Add(image);
            }
            return Json(ret);
        }
        public IActionResult Index()
        {

            return View(provider.Image.GetImages());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormFile f)
        {
            if (f != null)
            {
                provider.Image.Add(Save(f));
                return Redirect("/dashboard/image");

            }
            return View();
        }
        public IActionResult UploadMultiple()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadMultiple(IFormFile[] af)
        {
            if (af != null)
            {
                foreach (IFormFile f in af)
                {
                    provider.Image.Add(Save(f));
                }
                return Redirect("/dashboard/image");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            // xoa hinh anh trong Root
            string ImageUrl = Path.Combine(Root, provider.Image.GetUrlImageById(id));
            if (System.IO.File.Exists(ImageUrl))
            {
                System.IO.File.Delete(ImageUrl);
            }

            // xoa trong database
            provider.Image.Delete(id);
            return Redirect("/dashboard/image");
        }
        [HttpPost]
        public IActionResult DeleteMany(int[] ids)
        {
            IEnumerable<string> urls = provider.Image.GetUrlsById(ids);
            foreach (var url in urls)
            {
                string path = Path.Combine(Root, url);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            provider.Image.Delete(ids);
            return Redirect("/dashboard/image");
        }
        public IActionResult ClipBoard()
        {
            return View();
        }
        public IActionResult Folder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Folder(IFormFile[] af)
        {
            if (af != null)
            {
                foreach (var f in af)
                {
                    string folder = Path.GetDirectoryName(f.FileName);
                    string dir = Path.Combine(Root, folder);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string ext = Path.GetExtension(f.FileName);
                    string imageUrl = folder + "/" + Helper.RandomString(32 - ext.Length - folder.Length - 1) + ext;
                    using (Stream stream = new FileStream(Path.Combine(Root, imageUrl), FileMode.Create))
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
                }
                return Redirect("/dashboard/image");
            }
            return View();
        }
        public IActionResult Ajax(IFormFile f)
        {
            Image image = Save(f);
            return Json(provider.Image.Add(image));
        }
        public IActionResult WebUrl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WebUrl(string url)
        {
            using (WebClient client = new WebClient())
            {
                string ext = Path.GetExtension(url);
                string imageUrl = Helper.RandomString(32 - ext.Length) + ext;
                client.DownloadFile(url, Path.Combine(Root, imageUrl));
                Image obj = new Image
                {
                    ImageOriginal = Path.GetFileName(url),
                    ImageType = ext,
                    ImageUrl = imageUrl
                };
                provider.Image.Add(obj);
                return Redirect("/dashboard/image");
            }
        }
        public Image Save(IFormFile f)
        {
            // phan mo rong tap tin (.jpf, .png...)
            string ext = Path.GetExtension(f.FileName);
            string imageUrl = Helper.RandomString(32 - ext.Length) + ext;
            Console.WriteLine(imageUrl);
            string path = Path.Combine(Root, imageUrl);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                f.CopyTo(stream);
            }
            return new Image
            {
                ImageOriginal = f.FileName,
                ImageUrl = imageUrl,
                ImageSize = f.Length,
                ImageType = f.ContentType
            };
        }
    }
}
