using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SchoolWeb.API.DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
		#region Readonlys
		private readonly SchoolDbContext m_DbContext;
        private readonly DbSet<T> m_DbSet;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="context">The Database Context</param>
		public Repository(SchoolDbContext context)
        {
            m_DbContext = context;
            m_DbSet = context.Set<T>();
        }
		#endregion

		#region Methods
		#region Get & Any
		/// <summary>
		/// Gets a collection of entities based on the specified criteria.
		/// </summary>
		/// <param name="filter">The condition the entities must fulfil to be returned</param>
		/// <param name="orderBy">The function used to order the entities</param>
		/// <param name="includes">Any other navigation properties to include when returning the collection</param>
		/// <param name="top">The number of records to limit the results to</param>
		/// <param name="skip">The number of records to skip</param>
		/// <returns>A collection of entities</returns>
		public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			List<Expression<Func<T, object>>> includes = null,
			int? top = null,
			int? skip = null)
		{
			IQueryable<T> query = m_DbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (includes != null)
			{
				foreach (var includeProperty in includes)
				{
					query = query.Include(includeProperty);
				}
			}

			if (orderBy != null)
			{
				query = orderBy(query);
			}

			if (skip.HasValue)
			{
				query = query.Skip(skip.Value);
			}

			if (top.HasValue)
			{
				query = query.Take(top.Value);
			}

			return query.ToList();
		}
		
		/// <summary>
		/// Gets the first entity based on the specified criteria.
		/// </summary>
		/// <param name="filter">The condition the entities must fulfil to be returned</param>
		/// <param name="includeProperties">Any other navigation properties to include when returning the collection</param>
		/// <param name="top">The number of records to limit the results to</param>
		/// <param name="skip">The number of records to skip</param>
		/// <returns>A collection of entities</returns>
		public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
			string includeProperties = "",
			int? top = null,
			int? skip = null)
		{
			IQueryable<T> query = m_DbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (skip.HasValue)
			{
				query = query.Skip(skip.Value);
			}

			if (top.HasValue)
			{
				query = query.Take(top.Value);
			}

			return query.FirstOrDefault();
		}
		
		/// <summary>
		/// Gets an entity by ID.
		/// </summary>
		/// <param name="id">The ID of the entity to retrieve</param>
		/// <returns>The entity object if found, otherwise null</returns>
		public T GetById(object id)
		{
			return m_DbSet.Find(id);
		}

		/// <summary>
		/// Checks if any matching entries found after applying the filter.
		/// </summary>
		/// <param name="filter"></param>
		/// <returns>True, if match found. Otherwise false.</returns>
		public bool Any(Expression<Func<T, bool>> filter = null) 
			=> filter == null ? m_DbSet.Any() : m_DbSet.Any(filter);
		#endregion

		#region Add & Update
		/// <summary>
		/// Adds an entity.
		/// </summary>
		/// <param name="entity">The entity to add</param>
		public void Add(T entity)
		{
			m_DbSet.Add(entity);
		}

		/// <summary>
		/// Updates an entity.
		/// </summary>
		/// <param name="entity">The entity to add</param>
		public void Update(T entity)
		{
			m_DbSet.Attach(entity);
			m_DbContext.Entry(entity).State = EntityState.Modified;
		}

		/// <summary>
		/// Adds or Updates an entity.
		/// </summary>
		/// <param name="entity">The entity to add or update</param>
		/// <param name="shouldAdd">To know if we should add or update</param>
		public void AddOrUpdate(T entity, bool shouldAdd)
		{
			if (shouldAdd)
				Add(entity);
			else
				Update(entity);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Deletes an entity based on entity id.
		/// </summary>
		/// <param name="id">The entity id</param>
		public void Delete(object id)
		{
			T getObjById = m_DbSet.Find(id);
			m_DbSet.Remove(getObjById);
		}

		/// <summary>
		/// Deletes an entity based on condition.
		/// </summary>
		/// <param name="filter">The condition the entities must fulfil to be deleted</param>
		public void Delete(Expression<Func<T, bool>> filter = null)
		{
			m_DbSet.RemoveRange(m_DbSet.Where(filter));
		}
		#endregion
		#endregion
	}
}