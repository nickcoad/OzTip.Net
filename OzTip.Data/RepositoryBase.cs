using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OzTip.Interfaces;

namespace OzTip.Data
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class

    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _set;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public IRepository<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var includeProperty in includeProperties)
            {
                _set.Include(includeProperty);
            }

            return this;
        }

        public TEntity GetById(int id)
        {
            return _set.Find(id);
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> whereExpression)
        {
            return _set.Where(whereExpression);
        }

        public TEntity Create(TEntity entityToSave)
        {
            _set.Add(entityToSave);
            SaveChanges();

            return entityToSave;
        }

        public TEntity Update(TEntity entityToSave)
        {
            _context.Entry(entityToSave).State = EntityState.Modified;
            SaveChanges();

            return entityToSave;
        }

        public List<TEntity> Get()
        {
            return _set.ToList();
        }

        public void Delete(int id)
        {
            var toDelete = _context.Set<TEntity>().Find(id);
            _set.Remove(toDelete);

            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
