namespace WebApi.Models
{
    public abstract class BaseRepository
    {
        protected ShopContext context;
        public BaseRepository(ShopContext context)
        {
            this.context = context;
        }
    }
}
