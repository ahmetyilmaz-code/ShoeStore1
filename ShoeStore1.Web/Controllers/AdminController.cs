using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoeStore1.Service.DTOs;
using ShoeStore1.Web.Models.Services;
using ShoeStore1.Web.Models.ViewModels;


namespace ShoeStore1.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ProductService _productService;
        private readonly ProductSizeService _productSizeService;
        public AdminController(ProductService productService, ProductSizeService productSizeService)
        {
            _productService = productService;
            _productSizeService = productSizeService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AddProducts()
        {
            return View();
        }
        public IActionResult EditProducts()
        {
            var products = _productService.GetAdminProducts();
            return View(products);
        }
        public IActionResult ProductSizes(int id)
        {
            var product = _productService.GeyById(id);
            var sizes = _productSizeService.GetByProductId(id);

            ProductSizeViewModel model = new ProductSizeViewModel
            {
                ProductId = id,
                ProductName = product.Name,

                Sizes = sizes.Select(x => new ProductSizeStockViewModel
                {
                    Size = x.Size,
                    Stock = x.Stock
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveProductSizes(ProductSizeViewModel model)
        {
            List<ProductSizeDto> sizes = new List<ProductSizeDto>();
            foreach (var item in model.Sizes)
            {
                sizes.Add(new ProductSizeDto
                {
                    Size = item.Size,
                    Stock = item.Stock
                });
            }
            _productSizeService.SaveProductSizes(model.ProductId, sizes);
            return RedirectToAction("ProductSizes", new 
            {
                id = model.ProductId 
            });
        }
    }
}
