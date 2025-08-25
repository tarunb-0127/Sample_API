using Microsoft.EntityFrameworkCore;
using Sample_API.Models;
using System.Security.Cryptography.X509Certificates;

namespace Sample_API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<Product> Products { get; set; }

       
    }
}
