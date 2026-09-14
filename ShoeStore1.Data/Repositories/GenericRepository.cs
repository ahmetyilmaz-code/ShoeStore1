using Microsoft.EntityFrameworkCore;
using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using System.Linq.Expressions;


namespace ShoeStore1.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        // GenericRepository sınıfı, IGenericRepository arayüzünü uygular ve
        // BaseEntity sınıfından türetilmiş herhangi bir tür için temel CRUD işlemlerini sağlar.

        // T, BaseEntity sınıfından türetilmiş herhangi bir türü temsil eder.
        // Bu sayede, GenericRepository sınıfı farklı varlık türleri için kullanılabilir.

        // GenericRepository sınıfı, veri kaynağı ile etkileşimde bulunmak için gerekli olan temel CRUD işlemlerini sağlar.
        // Bu işlemler, Add, Delete, GetAll, GetById, Update ve Where metodlarını içerir.
        // Ancak, bu metodların içeriği henüz uygulanmamıştır ve NotImplementedException fırlatır.
        // Bu, geliştiricilere metodların henüz tamamlanmadığını ve çağrıldığında bir hata fırlatacağını gösterir.

        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); //
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            // Add metodu, belirtilen varlık nesnesini veri kaynağına eklemek için kullanılır.
            // Ancak, bu metodun içeriği henüz uygulanmamıştır ve NotImplementedException fırlatır.
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            // Delete metodu, belirtilen varlık nesnesini veri kaynağından silmek için kullanılır.
            // Ancak, bu metodun içeriği henüz uygulanmamıştır ve NotImplementedException fırlatır.

            // NotImplementedException, bir metodun veya özelliğin henüz uygulanmadığını belirtmek için kullanılan bir istisna türüdür.
            // Bu, geliştiricilere metodun henüz tamamlanmadığını ve çağrıldığında bir hata fırlatacağını gösterir.
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAllIsActive()
        {
            return _dbSet.Where(item => item.IsDeleted == false).ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
