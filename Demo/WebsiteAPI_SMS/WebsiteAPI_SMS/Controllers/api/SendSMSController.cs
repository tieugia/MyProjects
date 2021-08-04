using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteAPI_SMS.Controllers.api
{
    public class SendSMSController : Controller
    {
        // GET: SendSMS
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SendSMS_Model Send)
        {
            SpeedSMSAPI api = new SpeedSMSAPI(Send.token);

            string[] phones = Send.phone.Split(',');
            String str = Send.content;
            String response = api.sendSMS(phones, str, Send.type, Send.thuonghieu);
            Send.Status = response;

            return View(Send);
        }
    }
}