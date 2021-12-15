using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Access
    {
        public Guid AccessId { get; set; }
        public string AccessName { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string AccessUrl { get; set; }
    }
}
