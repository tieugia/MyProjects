namespace WebClient.Models
{
    public class CategoryRepository
    {
        public async Task<int> Delete(byte id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:46110");
                HttpResponseMessage message = await client.DeleteAsync($"/api/category/{id}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0;
            }
        }
        public async Task<int> Add(Category obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:46110");
                HttpResponseMessage message = await client.PostAsJsonAsync<Category>("/api/category", obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0;
            }
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:46110");
                HttpResponseMessage message = await client.GetAsync("/api/category");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<List<Category>>();
                }
                return null;
            }
        }
    }
}
