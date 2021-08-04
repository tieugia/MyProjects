using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebsiteAPI_SMS
{
    public class SendSMS_Model
    {
        [DisplayName("Access Token")]
        public string token { get; set; }
        [DisplayName("Điện thoại")]
        public string phone { get; set; }
        [DisplayName("Nội dung")]
        public string content { get; set; }
        [DisplayName("Thương hiệu")]
        public string thuonghieu { get; set; }
        [DisplayName("Loại")]
        public int type { get; set; }
        [DisplayName("Trạng thái")]
        public string Status { get; set; }

        public SendSMS_Model()
        {
            type = 2;
        }
    }
}