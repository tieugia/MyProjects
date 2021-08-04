using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVCCRUD.Models
{
    //[Key]
    //public int UserId { get; set; }
    //[Column(TypeName ="nvarchar(250)")]
    //[Required(ErrorMessage ="This field is required.")]
    //[DisplayName("Full Name")]
    //public string FullName { get; set; }
    //[Column(TypeName = "varchar(10)")]
    //[DisplayName("Phone Number")]
    //public string PhoneNumber { get; set; }
    //[Column(TypeName = "varchar(100)")]
    //public string Position { get; set; }
    public class Request
    {
        public string[] PhoneNumber { get; set; }
        public string Content { get; set; }
        public string AccessToken { get; set; }
        public string Sender { get; set; }
        public class Types
        {
            public const int TYPE_QC = 1;
            public const int TYPE_CSKH = 2;
            public const int TYPE_BRANDNAME = 3;
            public const int TYPE_BRANDNAME_NOTIFY = 4;
            public const int TYPE_GATEWAY = 5;
        }
        public static Request GetRequest()
        {
            Request request = new Request();
            return request;
        }
    }
}