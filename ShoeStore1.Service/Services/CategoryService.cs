using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Service.DTOs;
using ShoeStore1.Service.Helpers;

namespace ShoeStore1.Service.Services
{
    public class CategoryService : GenericService<Category>
    {
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public new CategoryDto GetById(int id)
        {
            return base.GetById(id).ToDto<CategoryDto>();
        }

        public new List<CategoryDto> GetAllIsActive()
        {
            return base.GetAllIsActive().ToDtoList<CategoryDto>().ToList();
        }

       

    }
}
