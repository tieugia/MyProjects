using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    [Table("Result")]
    public class Result
    {
        [Column("ResultId")]
        public int Id { get; set; }
        public short ProvinceId { get; set; }
        [Column("ResultDate")]
        public DateTime Date { get; set; }
        public Province Province { get; set; }
        public List<Number> Numbers { get; set; }
    }
}
