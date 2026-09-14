using ShoeStore1.Core.Repositories;

namespace ShoeStore1.Data.Repositories
{
    public class UnitofWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;
        public UnitofWork(AppDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
