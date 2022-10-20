using HC_AdminUI.Data;
using HC_AdminUI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HC_AdminUIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HC_AdminUIContext") ?? throw new InvalidOperationException("Connection string 'HC_AdminUIContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRegistroService, RegistroService>();
builder.Services.AddScoped<IPeliculasService, PeliculasService>();
builder.Services.AddScoped<IActividadesService, ActividadesService>();
builder.Services.AddScoped<IEstudiantesService, EstudiantesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();