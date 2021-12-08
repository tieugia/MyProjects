using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using WebApp.Models;

namespace WebApp.Area.Dashboard
{
    [Authorize(Roles = "admin")]
    [Area("dashboard")]
    [ServiceFilter(typeof(AccessFilter))]
    public class MemberController : Controller
    {
        MemberRepository member;
        RoleRepository role;
        MemberInRoleRepository memberInRole;
        SiteProvider provider;
        public MemberController(IConfiguration configuration)
        {
            member = new MemberRepository(configuration);
            role = new RoleRepository(configuration);
            memberInRole = new MemberInRoleRepository(configuration);
            provider = new SiteProvider(configuration);
        }
        [HttpPost]
        public IActionResult Roles(MemberInRole obj)
        {
            return Json(memberInRole.Add(obj));
        }
        public IActionResult Roles(string id)
        {
            //chưa đúng lắm
            //ViewBag.roles = role.GetRoles();
            ViewBag.roles = role.GetAllRolesByMemberId(id);
            //ViewBag.accesses = provider.Access.GetAccessesByMemberId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(member.GetMemberById(id));
        }
        
      public IActionResult Index()
        {
            //ViewBag.accesses = provider.Access.GetAccessesByMemberId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(member.GetMembers());
        }

    }
}
