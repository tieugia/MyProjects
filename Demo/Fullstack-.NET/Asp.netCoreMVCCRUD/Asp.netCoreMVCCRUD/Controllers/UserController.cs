using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.netCoreMVCCRUD.Models;
using System.Net;
using System.IO;

namespace Asp.netCoreMVCCRUD.Controllers
{
    public class SpeedSMSAPIController : Controller
    {
        private readonly UserContext _context;

        public SpeedSMSAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.requests.ToListAsync());
        }


        // GET: User/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Request());
            else
                return View(_context.requests.Find(id));
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("AccessToken,PhoneNumber,Content,Sender")] Request request)
        {
            if (ModelState.IsValid)
            {
                //if (Models.Request. == 0)
                //    _context.Add(User);
                //else
                _context.Update(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }


        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var User = await _context.requests.FindAsync(id);
            _context.requests.Remove(User);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
        const String rootURL = "https://api.speedsms.vn/index.php";
        private String accessToken = "Your access token";

        //public SpeedSMSAPI()
        //{

        //}

        public SpeedSMSAPIController(String token)
        {
            this.accessToken = token;
        }
        private string EncodeNonAsciiCharacters(string value)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char c in value)
            {
                if (c > 127)
                {
                    // This character is too big for ASCII
                    string encodedValue = "\\u" + ((int)c).ToString("x4");
                    sb.Append(encodedValue);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public String getUserInfo()
        {
            String url = rootURL + "/user/info";
            NetworkCredential myCreds = new NetworkCredential(accessToken, ":x");
            WebClient client = new WebClient();
            client.Credentials = myCreds;
            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            return reader.ReadToEnd();
        }
        //public ResponseObject sendSMSGo(Request req)
        //{
        public String sendSMS(String[] phones, String content, int type, String sender)
        {
            String url = rootURL + "/sms/send";
            if (phones.Length <= 0)
                return "";
            if (content.Equals(""))
                return "";

            if (type == Models.Request.Types.TYPE_BRANDNAME && sender.Equals(""))
                return "";

            NetworkCredential myCreds = new NetworkCredential(accessToken, ":x");
            WebClient client = new WebClient();
            client.Credentials = myCreds;
            client.Headers[HttpRequestHeader.ContentType] = "application/json";

            string builder = "{\"to\":[";

            for (int i = 0; i < phones.Length; i++)
            {
                builder += "\"" + phones[i] + "\"";
                if (i < phones.Length - 1)
                {
                    builder += ",";
                }
            }
            builder += "], \"content\": \"" + Uri.EscapeDataString(content) + "\", \"type\":" + type + ", \"sender\": \"" + sender + "\"}";

            String json = builder.ToString();
            return client.UploadString(url, json);
        }
        //}

        public String sendMMS(String[] phones, String content, String link, String sender)
        {
            String url = rootURL + "/mms/send";
            if (phones.Length <= 0)
                return "";
            if (content.Equals(""))
                return "";

            NetworkCredential myCreds = new NetworkCredential(accessToken, ":x");
            WebClient client = new WebClient();
            client.Credentials = myCreds;
            client.Headers[HttpRequestHeader.ContentType] = "application/json";

            string builder = "{\"to\":[";

            for (int i = 0; i < phones.Length; i++)
            {
                builder += "\"" + phones[i] + "\"";
                if (i < phones.Length - 1)
                {
                    builder += ",";
                }
            }
            builder += "], \"content\": \"" + Uri.EscapeDataString(content) + "\", \"link\": \"" + link + "\", \"sender\": \"" + sender + "\"}";

            String json = builder.ToString();
            return client.UploadString(url, json);
        }
    }
}
