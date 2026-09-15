using Microsoft.AspNetCore.Mvc;
using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Web.Models.ApiModel;
using ShoeStore1.Web.Models.Services;

namespace ShoeStore1.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        ProductService _productService;
        public ProductApiController(IGenericRepository<Product> repositoryProduct, IGenericRepository<Category> repositoryCategory, IGenericRepository<ProductSize> repositoryProductSize, IUnitOfWork unitOfWork)
        {
            ProductSizeService productSizeService = new ProductSizeService(repositoryProductSize, unitOfWork);
            _productService = new ProductService(repositoryProduct,repositoryCategory,unitOfWork,productSizeService);
        }

        [HttpPost("FilterProducts")]
        public IActionResult FilterProducts([FromBody] ProductApiModel model)
        {
            var list = _productService.GetProductApiFilter(model);
            return Ok(list);
        }
    }
}
