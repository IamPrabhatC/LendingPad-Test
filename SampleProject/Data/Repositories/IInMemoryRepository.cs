using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IInMemoryRepository<T> where T : class
    {
        /// <summary>
        /// Get an entity by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(Guid id);
        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Add an entity with a specific id.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task AddAsync(T entity, Guid id);
        /// <summary>
        /// Remove an entity by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveAsync(Guid id);
        /// <summary>
        /// Check if an entity with a specific id exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Guid id);
    }
}
