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
		public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
												  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
												  List<Expression<Func<T, object>>> includes = null,
												  int? top = null,
												  int? skip = null)
		{
			IQueryable<T> query = m_DbSet;
			if (filter != null)
				query = query.Where(filter);

			if (includes != null)
			{
				foreach (var includeProperty in includes)
					query = query.Include(includeProperty);
			}

			if (orderBy != null)
				query = orderBy(query);

			if (skip.HasValue)
				query = query.Skip(skip.Value);

			if (top.HasValue)
				query = query.Take(top.Value);

			return await query.ToListAsync();
		}

		/// <summary>
		/// Gets the first entity based on the specified criteria.
		/// </summary>
		/// <param name="filter">The condition the entities must fulfil to be returned</param>
		/// <param name="includeProperties">Any other navigation properties to include when returning the collection</param>
		/// <param name="top">The number of records to limit the results to</param>
		/// <param name="skip">The number of records to skip</param>
		/// <returns>Entity</returns>
		public async Task<T> GetFirstAsync(Expression<Func<T, bool>> filter = null,
													List<Expression<Func<T, object>>> includes = null,
													int? top = null,
													int? skip = null)
		{
			IQueryable<T> query = m_DbSet;
			if (filter != null)
				query = query.Where(filter);

			if (includes != null)
			{
				foreach (var includeProperty in includes)
					query = query.Include(includeProperty);
			}

			if (skip.HasValue)
				query = query.Skip(skip.Value);

			if (top.HasValue)
				query = query.Take(top.Value);

			return await query.FirstAsync();
		}

		/// <summary>
		/// Gets the first entity based on the specified criteria. If no entity is found, returns null.
		/// </summary>
		/// <param name="filter">The condition the entities must fulfil to be returned</param>
		/// <param name="includeProperties">Any other navigation properties to include when returning the collection</param>
		/// <param name="top">The number of records to limit the results to</param>
		/// <param name="skip">The number of records to skip</param>
		/// <returns>Entity or null</returns>
		public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null,
													List<Expression<Func<T, object>>> includes = null,
													int? top = null,
													int? skip = null)
		{
			IQueryable<T> query = m_DbSet;
			if (filter != null)
				query = query.Where(filter);

			if (includes != null)
			{
				foreach (var includeProperty in includes)
					query = query.Include(includeProperty);
			}

			if (skip.HasValue)
				query = query.Skip(skip.Value);

			if (top.HasValue)
				query = query.Take(top.Value);

			return await query.FirstOrDefaultAsync();
		}

		/// <summary>
		/// Gets an entity by ID.
		/// </summary>
		/// <param name="id">The ID of the entity to retrieve</param>
		/// <returns>The entity object if found, otherwise null</returns>
		public async Task<T> GetByIdAsync(object id)
		{
			return await m_DbSet.FindAsync(id);
		}

		/// <summary>
		/// Checks if any matching entries found after applying the filter.
		/// </summary>
		/// <param name="filter"></param>
		/// <returns>True, if match found. Otherwise false.</returns>
		public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null)
			=> filter == null ? await m_DbSet.AnyAsync() : await m_DbSet.AnyAsync(filter);
		#endregion

		#region Add & Update
		/// <summary>
		/// Adds an entity.
		/// </summary>
		/// <param name="entity">The entity to add</param>
		public async Task AddAsync(T entity)
		{
			await m_DbSet.AddAsync(entity);
		}

		/// <summary>
		/// Updates an entity. The Attach and Entry(entity).State = EntityState.Modified operations are typically not asynchronous 
		/// because they are in-memory operations. The database is not accessed until SaveChanges or SaveChangesAsync is called. 
		/// As a result, the Update operation itself is not inherently asynchronous because it doesn't involve I/O operations.
		/// But just to maintain a consistent API, the method signature is intentionally marked as if it is asynchronous but it is
		/// actually a method with synchronous operations.
		/// </summary>
		/// <param name="entity">The entity to add</param>
		public Task UpdateAsync(T entity)
		{
			m_DbSet.Attach(entity);
			m_DbContext.Entry(entity).State = EntityState.Modified;
			return Task.CompletedTask;
		}

		/// <summary>
		/// Adds or Updates an entity.
		/// </summary>
		/// <param name="entity">The entity to add or update</param>
		/// <param name="shouldAdd">To know if we should add or update</param>
		public async Task AddOrUpdateAsync(T entity, bool shouldAdd)
		{
			if (shouldAdd)
				await AddAsync(entity);
			else
				await UpdateAsync(entity);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Deletes an entity based on entity id.
		/// </summary>
		/// <param name="id">The entity id</param>
		public async Task DeleteAsync(object id)
		{
			T getObjById = await m_DbSet.FindAsync(id);
			m_DbSet.Remove(getObjById);
		}

		/// <summary>
		/// Deletes an entity based on condition.
		/// </summary>
		/// <param name="filter">The condition the entities must fulfil to be deleted</param>
		public async Task DeleteAsync(Expression<Func<T, bool>> filter = null)
		{
			var entitiesToDelete = await m_DbSet.Where(filter).ToListAsync();
			m_DbSet.RemoveRange(entitiesToDelete);
		}
		#endregion
		#endregion
	}
}