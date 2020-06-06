using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository<T> where T : class
    {
        int Add(T entity);
        int AddRange(IEnumerable<T> entities);
        int Remove(int id);
        int Remove(T entity);
        int RemoveRange(IEnumerable<T> entities);
        int Update(T entity);
        int UpdateRange(IEnumerable<T> entities);
        T Get(int entityId);
        IEnumerable<T> GetList(Func<T, bool> where);
        IEnumerable<T> GetAll();
        IQueryable<T> Query();
    }
}
