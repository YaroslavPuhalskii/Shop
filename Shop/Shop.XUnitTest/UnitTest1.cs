using Moq;
using Shop.Domain.Abstract;
using Shop.Domain.Entities;
using Shop.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Shop.XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns( new Product[] {
                new Product { ProductId = 1, Name = "A1" },
                new Product { ProductId = 2, Name = "A2" },
                new Product { ProductId = 3, Name = "A3" },
                new Product { ProductId = 4, Name = "A4" },
                new Product { ProductId = 5, Name = "A5"}
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);

            controller.PageSize = 3;

            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;
            // Assert
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("A4", prodArray[0].Name);
            Assert.Equal("A5", prodArray[1].Name);
        }
    }
}
