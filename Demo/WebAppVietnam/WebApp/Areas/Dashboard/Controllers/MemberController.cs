using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Models;

namespace WebApp.Area.Dashboard.Controllers
{
    [Area("dashboard")]
    [ServiceFilter(typeof(AccessFilter))]
    public class MemberController : Controller
    {
        //MemberRepository member;
        //RoleRepository role;
        //MemberInRoleRepository memberInRole;
        SiteProvider provider;
        public MemberController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        //public MemberController(IConfiguration configuration)
        //{
        //    member = new MemberRepository(configuration);
        //    role = new RoleRepository(configuration);
        //    memberInRole = new MemberInRoleRepository(configuration);
        //    provider = new SiteProvider(configuration);
        //}
        [Authorize]
        public IActionResult Index()
        {
            //ViewBag.accesses = provider.Access.GetAccessesByMemberId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(provider.Member.GetMembers());
        }
        [HttpPost]
        [Authorize]
        public IActionResult Roles(MemberInRole obj)
        {
            return Json(provider.MemberInRole.Add(obj));
        }
        [Authorize]
        public IActionResult Roles(string id)
        {
            //ViewBag.roles=role.GetRoles();
            ViewBag.roles = provider.Role.GetAllRolesByMemberId(id);
            //ViewBag.accesses = provider.Access.GetAccessesByMemberId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(provider.Member.GetMemberById(id));
        }
    }
}
