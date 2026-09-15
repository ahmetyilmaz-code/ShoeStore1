using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Service.DTOs;

namespace ShoeStore1.Service.Services
{
    public class ProductSizeService : GenericService<ProductSize>
    {
        public ProductSizeService(IGenericRepository<ProductSize> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public List<ProductSizeDto> GetByProductId(int productId)
        {
            var productSizes = Where(x => x.ProductId == productId && !x.IsDeleted);
            List<ProductSizeDto> result = new List<ProductSizeDto>();
            foreach (var item in productSizes)
            {
                result.Add(new ProductSizeDto
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Size = item.Size,
                    Stock = item.Stock
                });
            }
            return result;
        }
        public void AddProductSize(int productId, string size, int stock)
        {
            ProductSize productSize = new ProductSize
            {
                ProductId = productId,
                Size = size,
                Stock = stock
            };

            base.Add(productSize);
            base.Commit();
        }
        public void SaveProductSizes(int productId, List<ProductSizeDto> sizes)
        {
            foreach (var item in sizes)
            {
                var existingSize = Where(x => x.ProductId == productId && x.Size == item.Size && !x.IsDeleted).FirstOrDefault();

                if (existingSize != null)
                {
                    existingSize.Stock = item.Stock;
                    base.Update(existingSize);
                }
                else
                {
                    ProductSize productSize = new ProductSize
                    {
                        ProductId = productId,
                        Size = item.Size,
                        Stock = item.Stock
                    };

                    base.Add(productSize);
                }
            }

            base.Commit();
        }



    }
}
