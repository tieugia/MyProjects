using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.ModelViews;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        MemberRepository member;
        RoleRepository role;
        SiteProvider provider;
        public AuthController(IConfiguration configuration)
        {
            member = new MemberRepository(configuration);
            role = new RoleRepository(configuration);
        }
        public IActionResult Forgot(ForgotModel obj)
        {
            //thieu lien quan den token? dính tới database
            // gửi email + token sao fai dung token
            obj.Token = Helper.RandomString(32);
            int ret = provider.Member.UpdateMemberToken(obj);
            if(ret>0)
            {
                SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential("ltvnetcore@gmail.com", "$tvne!c0re")
                };
                MailAddress from = new MailAddress("ltvnetcore@gmail.com");
                MailAddress to = new MailAddress(obj.Email);
                MailMessage message = new MailMessage(from, to);
                obj.Token = Helper.RandomString(32);
                message.Subject = "Password Recovery from WebApp";
                message.Body = $"You click here for <a href=\"https://localhost:44385/auth/recovery/{obj.Token}\">Password Recovery</a>";
                message.IsBodyHtml = true;
                mailClient.Send(message);
                TempData["msg"] = $"Send Email Success.please check your email: {obj.Email}";
                return Redirect("/auth/success");
            }
            else
            {
                ModelState.AddModelError("", "Please email valid");
                return View(obj);
            }
           
        }
        public IActionResult Success()
        {
            return View();
        }
        //id = token
        public IActionResult Recovery(string id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Recovery(string id,RecoveryModel obj)
        {
            obj.Token = id;
            int ret = provider.Member.RecoveryPassword(obj);
            if(ret>0)
            {
                return Redirect("/auth/login");
            }
            ModelState.AddModelError("", "Token or Password Invalid");
            return View(obj);
        }
        public ActionResult Forgot()
        {
            return View();
        }
     
        public IActionResult Denied()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginModel  obj,string returnUrl)
        {
            Member ret = member.Login(obj);
            if(ret is null)
            {
                ModelState.AddModelError("", "Login Failed");
                return View(obj);
            }
            //khác null
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,ret.MemberId),
                new Claim(ClaimTypes.Name,ret.Username),
                new Claim(ClaimTypes.Email,ret.Email),
                new Claim(ClaimTypes.Gender,ret.Gender.ToString())
            };
            //Thiếu role
            IEnumerable<string> roles = role.GetRolesByMemberId(ret.MemberId);
            if(roles != null)
            {
                foreach(var item in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }    
            }    
            ClaimsIdentity identities = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identities);
            //liên quan đến cookies
            AuthenticationProperties properties = new AuthenticationProperties
            {
                IsPersistent = obj.Remember
            };
            //chạy bất đồng bộ
            await HttpContext.SignInAsync(principal, properties);
            if (string.IsNullOrEmpty(returnUrl))
            {
                return Redirect("/auth");
            }
            else
            {
                return Redirect(returnUrl);
            }
        }
        [Authorize]
        //1 application => 1 process => 1 thread
        // tách riêng 1 thread mới tự  xử lý , khi xử lý xong trả về kết quả
        public async Task<IActionResult> Logout()
        {
            //chạy lâu , tách thành 1 thread khác
            // chạy background ( chạy phía dưới)
            //khi hoàn thành trả về kêt quả
            //mục đích -> tách 1 thread riêng => ko bị treo máy
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/auth/login");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Member obj)
        {
            member.Add(obj);
            return Redirect("/auth");
        }
    }
}
