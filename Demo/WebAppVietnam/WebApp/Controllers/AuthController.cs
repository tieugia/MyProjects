using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using WebApp.Models;
using WebApp.ModelViews;

namespace WebApp.Controllers
{
    [ServiceFilter(typeof(AccessFilter))]
    public class AuthController : Controller
    {
        SiteProvider provider;
        public AuthController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Forgot(ForgotModel obj)
        {           
            obj.Token = Helper.RandomString(32);
            int ret = provider.Member.UpdateMemberToken(obj);
            if (ret > 0)
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
                message.Body = $"You click here for <a href=\"https://localhost:44348/auth/recovery/{obj.Token}\">Password Recovery</a>";
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
        public IActionResult Recovery(string id, RecoveryModel obj)
        {
            obj.Token = id;
            int ret = provider.Member.RecoveryPassword(obj);
            if (ret > 0)
            {
                return Redirect("/auth/login");
            }
            ModelState.AddModelError("", "Token or Password Invalid");
            return View(obj);
        }
        public IActionResult Denied()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/auth/login");
        }
        public IActionResult Login() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel obj, string returnUrl)
        {
            Member ret = provider.Member.Login(obj);
            if (ret is null)
            {
                ModelState.AddModelError("", "Login Failed");
                return View(obj);
            }
            // ret != null
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, ret.MemberId),
                new Claim(ClaimTypes.Name, ret.Username),
                new Claim(ClaimTypes.Email, ret.Email),
                new Claim(ClaimTypes.Gender, ret.Gender.ToString())
            };
            IEnumerable<string> roles = provider.Role.GetRolesByMemberId(ret.MemberId);
            if (roles != null)
            {
                foreach (var item in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }
            }
            ClaimsIdentity identities = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identities);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                IsPersistent = obj.Remember
            };
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
            provider.Member.Add(obj);
            return Redirect("/auth");
        }
    }
}
