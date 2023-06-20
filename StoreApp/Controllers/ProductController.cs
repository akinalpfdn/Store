using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        #region DI
        //This pattern is Dipendancy Injection Pattern,
        //When we created repository services on program.cs this will automatically used
        //instead of using commended context section below


        //Eskiden sadece dbContext varken bu kullaniliyordu, artik repomanager sistemine gectigimiz icin buna gerek yok
        //private readonly RepositoryContext _context;
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }



        #endregion
        public IActionResult Index()
        {
            /*
            var context = new RepositoryContext(
                new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite("Data Source = C:\\sqlite3\\MVC\\ProductDb.db").Options);
                */
            // return _context.Products;
            //var model = _context.Products.ToList();

            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            // Product product = _context.Products.First(p => p.ProductId.Equals(id));
            //return View(product);
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }
    }
}