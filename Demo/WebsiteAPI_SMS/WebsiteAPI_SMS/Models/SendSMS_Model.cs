using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteAPI_SMS
{
    public class SendSMS_Model
    {
        [DisplayName("Access Token")]
        [Required] public string token { get; set; }
        [DisplayName("Điện thoại")]
        [Required] public string phone { get; set; }
        [DisplayName("Nội dung")]
        [Required] public string content { get; set; }
        [DisplayName("Thương hiệu")]
        [Required] public string thuonghieu { get; set; }
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