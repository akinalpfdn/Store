using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
#region DI
//to easily use sql connection every where in the project
builder.Services.AddDbContext<RepositoryContext>(options =>{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));//appsettings.json uzerinde olusturulan connection stringin anahtar kelimesi
});
#endregion
var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
app.Run();
