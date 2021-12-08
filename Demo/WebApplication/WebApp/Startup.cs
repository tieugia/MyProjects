using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(p =>
           {
               p.LoginPath = "/auth/login";
               p.Cookie.Name = "cse.net.vn";
               //một số trang mình sẽ người dùng truy cập
               //dựa vào role

               p.AccessDeniedPath = "/auth/denied";
               //ghi log
               p.ExpireTimeSpan = TimeSpan.FromDays(30);
           });
            services.AddMvc();
            //Cơ chế DI
            services.AddScoped<AccessFilter>(p => new AccessFilter(configuration));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            //dòng này luon phải nằm dưới
            app.UseAuthorization();
            
          
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
              
                endpoints.MapControllerRoute(name: "dashboard", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");

            });
        }
    }
}
