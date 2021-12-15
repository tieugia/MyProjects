using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace Crawler
{
    [Table("Province")]
    public class Province
    {
        [Column("ProvinceId")]
        public short Id { get; set; }
        public short AreaId { get; set; }
        [Column("ProvinceName")]
        public string Name { get; set; }
        public byte PatternId { get; set; }
        public List<Result> Results { get; set; }
    }
}
