using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Service.Exceptions;
using System.Linq.Expressions;

namespace ShoeStore1.Service.Services
{
    public class GenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual void Add(T entity)
        {
            entity.CreateDate = DateTime.Now;
            _repository.Add(entity);
        }

        public virtual void Delete(int id)
        {
            T entity = GetById(id);
            entity.IsDeleted = true;
            
        }

        protected virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        protected virtual IEnumerable<T> GetAllIsActive()
        {
            return _repository.GetAllIsActive();
        }

        protected virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual void Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            _repository.Update(entity);
        }

        protected virtual IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public virtual void Remove(T entity)
        {            
            throw new NotRemoveException();
        }

       
    }
}
