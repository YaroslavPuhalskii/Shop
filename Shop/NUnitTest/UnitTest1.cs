using NUnit.Framework;
using System.Collections.Generic;
using Shop.Domain.Entities;
using Moq;
using System.Linq;
using Shop.Domain.Abstract;
using Shop.WebUI.Controllers;

namespace NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                      new Product {ProductId = 1, Name = "P1"},
                      new Product {ProductId = 2, Name = "P2"},
                      new Product {ProductId = 3, Name = "P3"},
                      new Product {ProductId = 4, Name = "P4"},
                      new Product {ProductId = 5, Name = "P5"}
            }.AsQueryable());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;
            // Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}