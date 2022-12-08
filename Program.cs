using LamartTest.Context;
using LamartTest.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<PointsDbContext>();
builder.Services.AddScoped<IPointRepository, PointRepository>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Point}/{action=HomePage}");
});
app.Run();