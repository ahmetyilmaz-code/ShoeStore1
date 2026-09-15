using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Service.DTOs;

namespace ShoeStore1.Web.Models.Services
{
    public class ProductSizeService
    {
        private readonly Service.Services.ProductSizeService _productSizeService;
        private readonly CategoryService _categoryService;        
        public ProductSizeService(IGenericRepository<ProductSize> repository, IUnitOfWork unitOfWork)
        {
            _productSizeService = new Service.Services.ProductSizeService(repository, unitOfWork);
        }
        public List<ProductSizeDto> GetByProductId(int productId)
        {
            return _productSizeService.GetByProductId(productId);
        }


        public void AddProductSize(int productId, string size, int stock)
        {
            _productSizeService.AddProductSize(productId, size, stock);
        }

        public void SaveProductSizes(int productId, List<ProductSizeDto> sizes)
        {
            _productSizeService.SaveProductSizes(productId, sizes);
        }

        public List<int> GetProductSizes(int productId)
        {
            return _productSizeService.GetByProductId(productId).Where(x => x.Stock > 0).Select(x => int.Parse(x.Size)).ToList();
        }
    }
}
