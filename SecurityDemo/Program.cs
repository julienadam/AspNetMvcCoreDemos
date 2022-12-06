using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecurityDemo.Data;
using SecurityDemo.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SecurityDemoContextConnection") ?? throw new InvalidOperationException("Connection string 'SecurityDemoContextConnection' not found.");

builder.Services.AddDbContext<SecurityDemoContext>(options => options.UseSqlServer(connectionString));

builder.Services
    .AddDefaultIdentity<AgeUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SecurityDemoContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 12;
    options.User.RequireUniqueEmail = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetService<UserManager<AgeUser>>();

    if (!await roleManager.RoleExistsAsync(Roles.Administrator))
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.Administrator));
    }

    if (await userManager.Users.CountAsync() == 1)
    {
        var user = userManager.Users.Single();
        await userManager.AddToRoleAsync(user, Roles.Administrator);
    }
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

app.MapRazorPages();

app.Run();
