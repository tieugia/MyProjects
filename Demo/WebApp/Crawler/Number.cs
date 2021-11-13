using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Crawler
{
    [Table("Number")]
    public class Number
    {
        [Column("NumberId")]
        public int Id { get; set; }
        [Column("NumberValue")]
        public string Value { get; set; }
        public byte PrizeId { get; set; }
        public int ResultId { get; set; }
        public Result Result { get; set; }
    }
}