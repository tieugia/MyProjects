var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapControllerRoute(name: "dashboard", pattern: "{area: exists}/{controller=home}/{action=index}/{id?}");
app.Run();
