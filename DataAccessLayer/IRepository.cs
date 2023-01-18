using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolWeb.API.DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = "");
        bool Any(Expression<Func<T, bool>> filter = null);
        T GetById(object Id);
        void Add(T obj);
        void Update(T obj);
        void AddOrUpdate(T obj, bool shouldAdd);
        void Delete(Object Id);
        void Delete(Expression<Func<T, bool>> filter);
        void Save();
    }
}
