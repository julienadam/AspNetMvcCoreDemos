using Microsoft.EntityFrameworkCore;
using Views.Entities;
using Views.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ChinookContext>();
builder.Services.AddDbContext<ChinookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Chinook")));
builder.Services.AddSingleton<IWeatherService, BogusWeatherService>();
builder.Services.AddSingleton<ProfileOptionsService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
