using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private readonly List<CartLine> cartLines = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine cartLine = cartLines.Where(x => x.Product.ProductId == product.ProductId)
                .FirstOrDefault();
            
            if (cartLine == null)
            {
                cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            cartLines.RemoveAll(x => x.Product.ProductId == product.ProductId);
        }

        public int TotalValueItems()
        {
            return cartLines.Sum(x => x.Product.Price * x.Quantity);
        }

        public void Clear()
        {
            cartLines.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return cartLines;
            }
        }

    }
}
