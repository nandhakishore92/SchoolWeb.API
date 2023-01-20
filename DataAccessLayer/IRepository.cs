using System.Linq.Expressions;

namespace SchoolWeb.API.DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
		#region Get
		T GetById(object Id);
		T GetFirstOrDefault(Expression<Func<T, bool>> filter);
		IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = "");
		bool Any(Expression<Func<T, bool>> filter = null);
		#endregion

		#region Add
		void Add(T entity);
		void AddRange(IEnumerable<T> entities);
		void AddOrUpdate(T entity, bool shouldAdd);
		#endregion

		#region Update
		void Update(T entity);
		void UpdateRange(IEnumerable<T> entities);
		#endregion

		#region Remove
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
		#endregion

		#region Async
		Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
		Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeProperties = "",
			CancellationToken cancellationToken = default);
		Task AddAsync(T entity, CancellationToken cancellationToken = default);
		Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
		#endregion
	}
}
