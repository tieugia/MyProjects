using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class PdfController : Controller
    {
        SiteProvider provider;
        public PdfController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public IActionResult Index()
        {
            return View(provider.Pdf.GetPdfs());
        }
        public IActionResult Detail(int id)
        {
            return View(provider.Pdf.GetPdfById(id));
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
                string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf");
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string url = Helper.RandomString(28) + ".pdf";
                using (Stream stream = new FileStream(Path.Combine(root, url), FileMode.Create))
                {
                    f.CopyTo(stream);
                }
                provider.Pdf.Add(new Pdf
                {
                    PdfUrl = url,
                    Size = f.Length
                });
                return Redirect("/dashboard/pdf");
            }
            return View();
        }
    }
}
