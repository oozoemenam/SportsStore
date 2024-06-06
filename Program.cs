using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using SportsStore.Repositories;
using SportsStore.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlite("Data Source=SportsStore.sqlite3")
);
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.MapControllerRoute(
    "catpage",
    "{category}/Page{productPage:int}",
    new { Controller = "Home", action = "Index" });
app.MapControllerRoute(
    "page",
    "Page{productPage:int}",
    new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute(
    "category",
    "{category}",
    new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute(
    "pagination",
    "Products/Page{productPage}",
    new { Controller = "Home", action = "Index", productPage = 1 });
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

// dotnet ef database drop --force --context StoreDbContext
SeedData.EnsurePopulated(app);

app.Run();