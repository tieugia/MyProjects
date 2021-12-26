namespace WebClient.Models
{
    public class SiteProvider
    {
        CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                if (category is null)
                {
                    category = new CategoryRepository();
                }
                return category;
            }
        }
    }
}
