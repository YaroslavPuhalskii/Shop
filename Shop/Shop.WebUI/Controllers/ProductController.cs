using Shop.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository repository)
        {
            productRepository = repository;
        }

        public ViewResult List()
        {
            return View(productRepository.Products);
        }
    }
}