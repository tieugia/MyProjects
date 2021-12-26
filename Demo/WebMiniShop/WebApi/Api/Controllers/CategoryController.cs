using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        SiteProvider provider;
        public CategoryController(SiteProvider provider)
        {
            this.provider = provider;
        }
        [HttpDelete("{id}")]
        public int Delete(byte id)
        {
            return provider.Category.Delete(id);
        }
        [HttpPost]
        public int Add(Category obj)
        {
            return provider.Category.Add(obj);
        }
        public List<Category> GetCategories()
        {
            return provider.Category.GetCategories();
        }
    }
}
