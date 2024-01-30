using System.Linq.Expressions;

namespace SchoolWeb.API.DataAccessLayer
{
	/// <summary>
	/// Base Repository Interface.
	/// </summary>
	/// <typeparam name="T">The Type of Entity to operate on</typeparam>
	public interface IRepository<T> where T : class
	{
		#region Get & Any
		Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
									  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
									  List<Expression<Func<T, object>>> includes = null,
									  int? top = null,
									  int? skip = null);
		Task<T> GetFirstAsync(Expression<Func<T, bool>> filter = null,
									   List<Expression<Func<T, object>>> includes = null,
									   int? top = null,
									   int? skip = null);

		Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null,
									   List<Expression<Func<T, object>>> includes = null,
									   int? top = null,
									   int? skip = null);

		Task<T> GetByIdAsync(object id);

		Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null);
		#endregion

		#region Add & Update
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task AddOrUpdateAsync(T entity, bool shouldAdd);
		#endregion

		#region Delete
		Task DeleteAsync(object id);
		Task DeleteAsync(Expression<Func<T, bool>> filter);
		#endregion
	}
}
