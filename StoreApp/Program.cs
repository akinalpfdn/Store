using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
#region DI
//to easily use sql connection every where in the project
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),//appsettings.json uzerinde olusturulan connection stringin anahtar kelimesi
    b => b.MigrationsAssembly("StoreApp"));
});
#endregion
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
