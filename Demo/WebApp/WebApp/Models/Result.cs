using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Result
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public short ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}
