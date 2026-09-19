using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trachChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trachChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        int CountByCondition(Expression<Func<T,bool>> expression);
    }
}
