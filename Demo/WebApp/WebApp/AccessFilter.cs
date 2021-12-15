using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class AccessFilter : IActionFilter
    {
        SiteProvider provider;
        public AccessFilter(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //bỏ vào viewbag
            if(context.Controller is Controller controller)
            {
                IEnumerable<Access> accesses = provider.Access.GetAccessesByMemberId(controller.User.FindFirstValue(ClaimTypes.NameIdentifier));
                if(accesses != null && accesses.Count()>0)
                {
                    controller.ViewBag.accesses = accesses;
                }    
            }    
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }
    }
}
