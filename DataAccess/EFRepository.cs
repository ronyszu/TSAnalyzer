using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class EFRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;
        public EFRepository(EFDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public int AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            return _context.SaveChanges();
        }

        public T Get(int entityId)
        {
            return _dbSet.Find(entityId);
        }

        public T Get(int entityId, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = null;
            for (int i = 0; i < includes.Length; i++)
            {
                query = _dbSet.Include(includes[i]);
            }

            return query.FirstOrDefault(x => x.Id == entityId);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable().ToList();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = null;
            for (int i = 0; i < includes.Length; i++)
            {
                query = _dbSet.Include(includes[i]);
            }

            return query.AsEnumerable();
        }

        public IEnumerable<T> GetList(Func<T, bool> where)
        {
            return _dbSet.Where(where).AsEnumerable();
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public int Remove(T entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges();
        }

        public int Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            return _context.SaveChanges();
        }

        public int RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public int UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }

            return _context.SaveChanges();
        }
    }
}
