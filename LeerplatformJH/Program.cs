using LeerplatformJH.Data;
using LeerPlatformJH.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using LeerplatformJH.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Microsoft.AspNetCore;
using LeerplatformJH.Services.Interfaces;
using LeerplatformJH.Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddIdentity<Gebruiker, IdentityRole>().AddRoles<IdentityRole>()
        
   .AddEntityFrameworkStores<ApplicationDbContext>()
   .AddDefaultTokenProviders();

    builder.Services.AddMvc();
    builder.Services.AddControllersWithViews().AddJsonOptions(opts =>
    opts.JsonSerializerOptions.PropertyNamingPolicy = null);

    builder.Services.AddScoped<IAdminsService, AdminsService>();
    builder.Services.AddScoped<IDocentService, DocentService>();
    builder.Services.AddScoped<ILesService, LesService>();
    builder.Services.AddScoped<ILokaalService, LokaalService>();
    builder.Services.AddScoped<IStudentService, StudentService>();
    builder.Services.AddScoped<IVakInschrijvingService, VakInschrijvingService>();
    builder.Services.AddScoped<IVakService, VakService>();
    builder.Services.AddScoped<IRegisterService, RegisterService>();


}
var app = builder.Build();
string[] ROLES = { "Admin", "Docent", "User" };



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
async Task CreateRolesAsync(IServiceProvider serviceProvider)
{
    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var UserManager = serviceProvider.GetRequiredService<UserManager<Gebruiker>>();

    CreateRolesAsync(serviceProvider).Wait();

    IdentityResult roleResult;

    foreach (string role in ROLES)
    {
        var roleCheck = await RoleManager.RoleExistsAsync(role);
        if (!roleCheck)
        {
            roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
        }
    }

    Gebruiker gebruiker = await UserManager.FindByEmailAsync("Jan.Hanssen@hotmail.com");
    if (gebruiker != null)
    {
        foreach (string role in ROLES)
        {
            await UserManager.AddToRoleAsync(gebruiker, role);
        }
    }
}