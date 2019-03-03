using OK.Northwind.Business.Abstract;
using OK.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OK.NorthWind.Entities.Concrete;

namespace OK.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "tv",
                UnitPrice = 12,
                QuantityPerUnit = "1"
            });
            return "Added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "Phone",
                UnitPrice = 2,
                QuantityPerUnit = "1"
            }, new Product
            {
                CategoryId = 1,
                ProductName = "t",
                UnitPrice = 2,
                QuantityPerUnit = "1",
                ProductId = 2
            });

            return "Done";
        }
    }
}