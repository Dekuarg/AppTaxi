using Microsoft.EntityFrameworkCore;
using probandoboton.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Datapriv");
builder.Services.AddDbContext<ApplicationUser>(mysqlBuilder => mysqlBuilder.UseMySQL(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();
//
builder.Services.AddDistributedMemoryCache();
//
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1800);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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

app.UseSession();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Access}/{action=Create}/{id?}");

    app.Run();
});