using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(p => {
        p.LoginPath = "/auth/login";
        p.Cookie.Name = "cherryCookies";
        //Phân quyền theo role (một số trang sẽ chặn người dùng truy cập)
        p.AccessDeniedPath = "/auth/denied";
        //Ghi log
        p.ExpireTimeSpan = TimeSpan.FromDays(30);
    });

builder.Services.AddMvc();
builder.Services.AddScoped<AccessFilter>(p => new AccessFilter(builder.Configuration));
var app = builder.Build();
app.UseStaticFiles();
app.UseAuthentication();
//Author duoi Authen
app.UseAuthorization();
//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();
app.MapControllerRoute(name: "dashboard", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");
app.Run();
