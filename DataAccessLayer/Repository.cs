using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SchoolWeb.API.DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private SchoolDbContext m_DbContext;
        private readonly DbSet<T> m_DbSet;

        public Repository(SchoolDbContext context)
        {
            m_DbContext = context;
            m_DbSet = context.Set<T>();
        }
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = m_DbSet;
            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public bool Any(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = m_DbSet;
            if (filter != null)
                return query.Any(filter);

            return query.Any();
        }

        public T GetById(object Id)
        {
            return m_DbSet.Find(Id);
        }

        public void Add(T obj)
        {
            m_DbSet.Add(obj);
        }
        public void Update(T obj)
        {
            m_DbSet.Attach(obj);
            m_DbContext.Entry(obj).State = EntityState.Modified;
        }
        public void AddOrUpdate(T obj, bool shouldAdd)
        {
            if (shouldAdd)
                Add(obj);
            else
                Update(obj);
        }
        public void Delete(object Id)
        {
            T getObjById = m_DbSet.Find(Id);
            m_DbSet.Remove(getObjById);
        }
        public void Delete(Expression<Func<T, bool>> filter = null)
        {
            m_DbSet.RemoveRange(m_DbSet.Where(filter));
        }
        public void Save()
        {
            m_DbContext.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.m_DbContext != null)
                {
                    this.m_DbContext.Dispose();
                    this.m_DbContext = null;
                }
            }
        }
    }
}