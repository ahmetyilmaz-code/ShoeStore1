using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Service.DTOs;
using ShoeStore1.Web.Models.ApiModel;
using ShoeStore1.Web.Models.ViewModels;

namespace ShoeStore1.Web.Models.Services
{
    public class ProductService
    {
        readonly Service.Services.ProductService _productService;
        readonly CategoryService _categoryService;
        public ProductService(IGenericRepository<Product> repositoryProduct, IGenericRepository<Category> repositoryCategory, IUnitOfWork unitOfWork)
        {
            _productService = new Service.Services.ProductService(repositoryProduct, unitOfWork);
            _categoryService = new CategoryService(repositoryCategory, unitOfWork);
        }

        public HomeViewModel GetHomeViewProductModel()
        {
            var featured = _productService.GetFeaturedList();
            var nonFeatured = _productService.GetFeaturedNonList();

            List<ProductDisplayModel> productsFeatured = new List<ProductDisplayModel>();
            List<ProductDisplayModel> productsNonFeatured = new List<ProductDisplayModel>();

            foreach (var feature in featured)
            {
                productsFeatured.Add(new ProductDisplayModel
                {
                    Category = _categoryService.GetByIdForName(feature.CategoryId),
                    Description = feature.Description,
                    Id = feature.Id,
                    ImageUrl = feature.ImageUrl,
                    Name = feature.Name,
                    Price = feature.Price.ToString(),
                    Sizes = new List<int> { 38, 39, 40, 41, 42 }
                });
            }
            foreach (var nonfeature in nonFeatured)
            {
                productsNonFeatured.Add(new ProductDisplayModel
                {
                    Category = _categoryService.GetByIdForName(nonfeature.CategoryId),
                    Description = nonfeature.Description,
                    Id = nonfeature.Id,
                    ImageUrl = nonfeature.ImageUrl,
                    Name = nonfeature.Name,
                    Price = nonfeature.Price.ToString(),
                    Sizes = new List<int> { 38, 39, 40, 41, 42 }
                });
            }

            HomeViewModel home = new HomeViewModel
            {
                FeatureProducts = productsFeatured,
                LatestProducts = productsNonFeatured
            };
            return home;
        }

        public List<ProductDisplayModel> GetProductApiFilter(ProductApiModel model)
        {
            var filterList = _productService.GetAllIsActive().AsQueryable();
            if (model.categories != null && model.categories.Any())
            {
                filterList = filterList.Where(p => model.categories.Contains(p.CategoryId));
            }
            if (model.maxPrice.HasValue)
            {
                filterList = filterList.Where(p => p.Price <= model.maxPrice);
            }
            if (model.minPrice.HasValue)
            {
                filterList = filterList.Where(p => p.Price >= model.minPrice);
            }

            List<ProductDisplayModel> products = new List<ProductDisplayModel>();
            foreach (var item in filterList)
            {
                products.Add(new ProductDisplayModel
                {
                    Description = item.Description,
                    Id = item.Id,
                    ImageUrl = item.ImageUrl,
                    Name = item.Name,   
                    Price = item.Price.ToString(),
                    Sizes = new List<int> { 38, 39, 40, 41, 42 },
                    Category = _categoryService.GetByIdForName(item.CategoryId)
                });
            }
            return products;

        }

        public ProductDTo GeyById(int id)
        {
            return _productService.GetById(id); 
        }


    }
}
