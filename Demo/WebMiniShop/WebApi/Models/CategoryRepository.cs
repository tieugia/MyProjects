namespace WebApi.Models
{
    public class CategoryRepository:BaseRepository
    {
        public CategoryRepository(ShopContext context) : base(context) { }
        public Category GetCategoryById(byte id)
        {
            return context.Categories.Find(id);
        }
        public int Edit(Category obj)
        {
            context.Categories.Update(obj);
            return context.SaveChanges();
        }
        public int Delete(byte id)
        {
            context.Categories.Remove(new Category { Id = id });
            return context.SaveChanges();
        }
        public int Add(Category obj)
        {
            context.Categories.Add(obj);
            return context.SaveChanges();
        }
        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
    }
}
