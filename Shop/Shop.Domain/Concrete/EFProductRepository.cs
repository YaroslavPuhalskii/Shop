using Shop.Domain.Abstract;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products 
        {
            get 
            {
                return context.Products;
            }
        }

        public Product DeleteProduct(int productId)
        {
            Product product = context.Products.Find(productId);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }

            return product;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product pr = context.Products.Find(product.ProductId);
                if (pr != null)
                {
                    pr.Name = product.Name;
                    pr.Description = product.Description;
                    pr.Category = product.Category;
                    pr.Price = product.Price;
                }
            }

            context.SaveChanges();
        }
    }
}
