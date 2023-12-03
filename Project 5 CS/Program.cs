using Microsoft.EntityFrameworkCore;
using Project_5_CS.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container for LoginDbContext
builder.Services.AddDbContext<LoginDbContext>(options =>
    options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Conor\\Documents\\LoginMusic.mdf;Integrated Security=True;Connect Timeout=30"));

// Add services to the container for YourDbContext (for Music database)
builder.Services.AddDbContext<MusicDbContext>(options =>
    options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Conor\\Documents\\Music.mdf;Integrated Security=True;Connect Timeout=30"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Other middleware configurations

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
