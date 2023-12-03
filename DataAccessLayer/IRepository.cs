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
		IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			List<Expression<Func<T, object>>> includes = null,
			int? top = null,
			int? skip = null);
		T GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
			string includeProperties = "",
			int? top = null,
			int? skip = null);
		T GetById(object id);
		bool Any(Expression<Func<T, bool>> filter = null);
		#endregion

		#region Add & Update
		void Add(T entity);
		void Update(T entity);
		void AddOrUpdate(T entity, bool shouldAdd);
		#endregion

		#region Delete
		void Delete(Object id);
		void Delete(Expression<Func<T, bool>> filter);
		#endregion
	}
}
