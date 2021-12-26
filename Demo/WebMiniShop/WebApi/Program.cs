using Microsoft.EntityFrameworkCore;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddMvc();
builder.Services.AddDbContext<ShopContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("MiniShop")));
builder.Services.AddScoped<SiteProvider>(p=>new SiteProvider(p.GetService<ShopContext>()));
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
//app.MapGet("/", () => "Hello World!");

app.Run();
