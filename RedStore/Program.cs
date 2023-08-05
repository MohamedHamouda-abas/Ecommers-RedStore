using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using RedStore.Models;
using System.Net.NetworkInformation;
using Bl;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

////aDD DB In JsonFile
builder.Services.AddDbContext<RedStoreShopContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped< IHeader, ClsHeader>();
builder.Services.AddScoped<Ioffers, ClsOffers>();
builder.Services.AddScoped<IFeatured, ClsFeatured>();
builder.Services.AddScoped<IProducts, ClsProducts>();
builder.Services.AddScoped<Itesmoniles, ClsTesMoniles>();





builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
	options.Password.RequiredLength = 8;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireUppercase = true;
	options.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<RedStoreShopContext>();



//builder.Services.AddScoped<VmHomePage>();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/User/AccessDenied";
    options.Cookie.Name = "Cookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(720);
    options.LoginPath = "/User/Login";
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//session
app.UseSession();

//identity
app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => {

	/* For Admin */

	endpoints.MapControllerRoute(
		 name: "admin",
		 pattern: "{area:exists}/{controller=Home}/{action=AdminPage}");

	/* For Home */

	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=HomePage}/{id?}");

});
app.Run();
