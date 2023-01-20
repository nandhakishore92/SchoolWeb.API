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

		#region Get
		public T GetById(object Id) => m_DbSet.Find(Id);

		public T GetFirstOrDefault(Expression<Func<T, bool>> filter) => m_DbSet.FirstOrDefault(filter);

		public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
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

        public bool Any(Expression<Func<T, bool>> filter = null) => filter != null ? m_DbSet.Any(filter) : m_DbSet.Any();
		#endregion

		#region Add
		public void Add(T entity) => m_DbContext.Add(entity);

		public void AddRange(IEnumerable<T> entities) => m_DbContext.AddRange(entities);

		public void AddOrUpdate(T entity, bool shouldAdd)
		{
			if (shouldAdd)
				Add(entity);
			else
				Update(entity);
		}
		#endregion

		#region Update
		public void Update(T entity) => m_DbContext.Update(entity);

		public void UpdateRange(IEnumerable<T> entities) => m_DbContext.UpdateRange(entities);
		#endregion

		#region Remove
		public void Remove(T entity) => m_DbContext.Remove(entity);

		public void RemoveRange(IEnumerable<T> entities) => m_DbContext.RemoveRange(entities);
		#endregion

		#region Async
		public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
			=> await m_DbSet.FirstOrDefaultAsync(filter, cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            CancellationToken cancellationToken = default)
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
				return await orderBy(query).ToListAsync(cancellationToken);
			else
				return await query.ToListAsync(cancellationToken);
        }

		public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
		   => await m_DbContext.AddAsync(entity, cancellationToken);

		public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
			=> await m_DbContext.AddRangeAsync(entities, cancellationToken);
		#endregion
	}
}