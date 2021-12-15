using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class Prize
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public List<Number> Numbers { get; set; }
    }
}