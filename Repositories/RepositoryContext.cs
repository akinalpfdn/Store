using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        //Baslangicta databasein verilerinin bos olmamasi icin default veri tanimlamari yapilacak
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() { ProductId = 1, ProductName = "Computer", Price = 17_000 },
                    new Product() { ProductId = 2, ProductName = "KeyBoard", Price = 7_000 },
                    new Product() { ProductId = 3, ProductName = "Mouse", Price = 1_000 },
                    new Product() { ProductId = 4, ProductName = "Speaker", Price = 5_000 },
                    new Product() { ProductId = 5, ProductName = "Microphone", Price = 1_000 }
                );
        }
        ///cmdde yazilan kodlar:
        //dotnet ef migrations add init sqlin olusmasi icin ilgili scriptleri hazirliyor
        //dotnet ef migrations add ProductSeedData sqlde guncelleme yapildiysa ilgili scriptleri haziyliyor
        //dotnet ef database update scriptlere gore sqli guncelliyor

    }
}
