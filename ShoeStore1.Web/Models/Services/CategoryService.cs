using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Service.DTOs;
using ShoeStore1.Web.Models.ViewModels;

namespace ShoeStore1.Web.Models.Services
{
    public class CategoryService
    {
        readonly Service.Services.CategoryService _categoryService;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork)
        {
            _categoryService = new Service.Services.CategoryService(repository, unitOfWork);
        }

        public CategoryDto GetById(int id)
        {
            return _categoryService.GetById(id);
        }
        public string GetByIdForName(int id)
        {
            var category = _categoryService.GetById(id);
            return category?.Name;
        }

        public List<CategoryViewModel> GetAllCategoryForName()
        {
            var list = _categoryService.GetAllIsActive();
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (var category in list)
            {
                categories.Add(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return categories;
        }

    }
}
