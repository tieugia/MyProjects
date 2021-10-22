using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Province
    {
        public short Id { get; set; }
        public byte PatternId { get; set; }
        public short AreaId { get; set; }
        public string AreaName { get; set; }
        public string Name { get; set; }
    }
}
