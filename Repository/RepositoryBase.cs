using System.Linq.Expressions;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) => RepositoryContext = repositoryContext;

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }
        
        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public int CountByCondition(Expression<Func<T,bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).Count();
        }

        public IQueryable<T> FindAll(bool trachChanges) => 
            !trachChanges ? 
            RepositoryContext.Set<T>().AsNoTracking() : 
            RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trachChanges) =>
            !trachChanges ?
            RepositoryContext.Set<T>().Where(expression).AsNoTracking() :
            RepositoryContext.Set<T>().Where(expression);

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }
    }
}
