using Microsoft.EntityFrameworkCore;
using SportsStore.Repositories;
using SportsStore.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlite("Data Source=SportsStore.sqlite3") 
);
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    "pagination",
    "Products/Page{productPage}",
    new { Controller = "Home", action = "Index" }
);
app.MapDefaultControllerRoute();

// dotnet ef database drop --force --context StoreDbContext
SeedData.EnsurePopulated(app);

app.Run();