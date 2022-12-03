using Microsoft.AspNetCore.Routing.Constraints;
using Routing.Plumbing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    name: "year month",
    pattern: "{year}/{month}",
    defaults: new { controller = "Home", action = "YearMonth" },
    constraints: new { year = @"\d{4}", month = new RangeRouteConstraint(1, 12) });

app.MapControllerRoute(
    name: "isin",
    pattern: "trade/{isin}",
    defaults: new { controller = "Trade", action = "Make" },
    constraints: new { isin = new IsinConstraint() });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "blog",
    pattern: "blog/{*slug}",
    defaults: new { controller = "Posts", action = "ViewPost"});

app.Run();
