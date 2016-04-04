using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OzTip.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        TEntity GetById(int id);

        List<TEntity> Get();

        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> whereExpression);

        IRepository<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Create(TEntity entityToSave);

        TEntity Update(TEntity entityToSave);

        void SaveChanges();

        void Delete(int id);
    }
}
