using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class MemberInRole
    {
        public string MemberId { get; set; }
        public Guid RoleId { get; set; }
    }
}
