using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Number
    {
        public long Id { get; set; }
        public byte PrizeId { get; set; }
        //public short ProvinceId { get; set; }
        public int ResultId { get; set; }
        public string Value { get; set; }
        //public DateTime Date { get; set; }
    }
}
