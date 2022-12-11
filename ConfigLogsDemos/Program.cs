using ConfigLogsDemos.Config;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.Configure<CustomCommon>(
//    builder.Configuration.GetSection(nameof(CustomCommon)));

var opt = builder.Configuration.GetSection(nameof(CustomCommon)).Get<CustomCommon>();
Console.WriteLine(opt.Abc);


var app = builder.Build();


foreach (var (key, value) in app.Configuration.AsEnumerable())
{
    Console.WriteLine($"Config key {key}\t\t{value}");
}

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

app.Run();
