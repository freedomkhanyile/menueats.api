
namespace menueats.api.DAL.Repository.RepositoryBase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using menueats.api.DAL.Contracts.IRepositoryBase;
    using menueats.api.DAL.DbContext;
 public abstract class RepositoryBase<T>
        : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return _repositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _repositoryContext.Set<T>().Where(expression);
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
        }
    }
}