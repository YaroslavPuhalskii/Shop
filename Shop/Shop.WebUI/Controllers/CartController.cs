using Shop.Domain.Abstract;
using Shop.Domain.Entities;
using Shop.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository productRepository;
        public CartController(IProductRepository prod)
        {
            productRepository = prod;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = productRepository.Products
                .FirstOrDefault(x => x.ProductId == productId);

            if (product == null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl});
        }

        public RedirectToRouteResult RemoveCart(int productId, string returnUrl)
        {
            Product product = productRepository.Products
                .FirstOrDefault(x => x.ProductId == productId);

            if (product != null)
            {
                GetCart().RemoveItem(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}