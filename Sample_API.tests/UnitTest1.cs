using NUnit.Framework;

using Microsoft.EntityFrameworkCore;

using Sample_API.Controllers;

using Sample_API.Data;

using Sample_API.Models;

using System.Collections.Generic;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace Sample_API.Tests

{

    public class ProductsControllerTests

    {

        private ProductDbContext _context;

        private ProductsController _controller;

        [SetUp]

        public void Setup()

        {

            var options = new DbContextOptionsBuilder<ProductDbContext>()

                .UseInMemoryDatabase(databaseName: "TestDb")

                .Options;

            _context = new ProductDbContext(options);

            _context.Products.Add(new Product { Id = 1, Name = "Tea", Price = 10 , Description="Sample"});

            _context.Products.Add(new Product { Id = 2, Name = "Coffee", Price = 20, Description= "Sample" });

            _context.SaveChanges();

            _controller = new ProductsController(_context);

        }

        [Test]

        public async Task GetProducts_ReturnsAllProducts()

        {

            // Act

            var result = await _controller.GetProducts();

            // Assert

            Assert.IsInstanceOf<ActionResult<IEnumerable<Product>>>(result);

            Assert.AreEqual(2, result.Value.Count());

        }

        [TearDown]

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
 