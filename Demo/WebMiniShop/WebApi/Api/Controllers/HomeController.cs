using Microsoft.AspNetCore.Mvc;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public string Welcome()
        {
            return "Welcome Ladies and Gentlemen";
        }
    }
}
