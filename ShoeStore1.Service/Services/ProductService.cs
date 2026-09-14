using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Service.DTOs;
using ShoeStore1.Service.Helpers;

namespace ShoeStore1.Service.Services
{
    public class ProductService : GenericService<Product>
    {
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
        public override void Add(Product entity)
        {
            base.Add(entity);
            Commit();
        }
        public override void Delete(int id)
        {
            base.Delete(id);
            Commit();
        }
        public override void Update(Product entity)
        {
            base.Update(entity);
            Commit();
        }
        public new ProductDTo GetById(int id)
        {
            var product = base.GetById(id);
            return product.ToDto<ProductDTo>();
        }
        public new List<ProductDTo> GetAll()
        {
            return base.GetAll().ToDtoList<ProductDTo>().ToList();
            //base.GetAll() ile tüm ürünleri alır,
            //ProductDTo tipine dönüştürür ve List<ProductDTo> olarak geri döndürür.
        }
        public new List<ProductDTo> GetAllIsActive()
        {
            return base.GetAllIsActive().ToDtoList<ProductDTo>().ToList();
        }
        
        public List<ProductDTo> GetFeaturedList()
        {
            return base.GetAll().Where(x => x.Featured).ToDtoList<ProductDTo>().ToList();
        }
        public List<ProductDTo> GetFeaturedNonList()
        {
            return base.GetAll().Where(x => !x.Featured).ToDtoList<ProductDTo>().ToList();
        }
    }
}
