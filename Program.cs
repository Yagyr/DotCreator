using LamartTest.Context;
using LamartTest.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<DbPoints>();
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Point}/{action=HomePage}");
});
app.Run();