using Microsoft.EntityFrameworkCore;
using WebMVC_Samborns.Models.Context;
using WebMVC_Samborns.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("Conexion");
builder.Services.AddDbContext<EmpresaContext>(x => x.UseSqlServer(connection));

builder.Services.AddHttpClient<EmpleadosService>();
builder.Services.AddHttpClient<AreaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empleados}/{action=Index}/{id?}");

app.Run();
