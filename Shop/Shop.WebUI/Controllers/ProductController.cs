using Shop.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Web;
using System.Web.Mvc;
using Shop.WebUI.Models;

namespace Shop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        public int PageSize = 4;
        public ProductController(IProductRepository repository)
        {
            productRepository = repository;
        }

        public ViewResult List(int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = productRepository.Products.OrderBy(x => x.ProductId)
                .Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = productRepository.Products.Count()
                }
            };

            return View(model);
        }
    }
}