using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        #region DI
        //This pattern is Dipendancy Injection Pattern,
        //When we created repository services on program.cs this will automatically used
        //instead of using commended context section below
        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context)
        {
            _context = context;
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
            var model = _context.Products.ToList();
            return View(model);
        }

        public IActionResult Get(int id)
        {
            Product product = _context.Products.First(p => p.ProductId.Equals(id));
            return View(product);
        }
    }
}