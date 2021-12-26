namespace WebApi.Models
{
    public class SiteProvider : IDisposable
    {
        ShopContext context;
        public SiteProvider(ShopContext context) { this.context = context; }
        CategoryRepository categoryRepository;
        public CategoryRepository Category
        {
            get
            {
                if (categoryRepository is null)
                {
                    categoryRepository = new CategoryRepository(context);
                }
                return categoryRepository;
            }
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}