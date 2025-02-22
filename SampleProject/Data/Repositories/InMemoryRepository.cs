using Common;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class InMemoryRepository<T> : IInMemoryRepository<T> where T : class
    {
        protected readonly ConcurrentDictionary<Guid, T> _store = new ConcurrentDictionary<Guid, T>();

        /// <summary>
        /// Get an entity by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetAsync(Guid id)
        {
            _store.TryGetValue(id, out T value);
            return Task.FromResult(value);
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult((IEnumerable<T>)_store.Values);
        }

        /// <summary>
        /// Add an entity with a specific id.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task AddAsync(T entity, Guid id)
        {
            if (!_store.TryAdd(id, entity))
            {                               
                throw new ArgumentException($"An entity with ID {id} already exists.");                
            }          
            return Task.CompletedTask;
        }
        /// <summary>
        /// Remove an entity by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id)
        {
            _store.TryRemove(id, out _);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Check if an entity with a specific id exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> ExistsAsync(Guid id)
        {
            return Task.FromResult(_store.ContainsKey(id));
        }
    }
}
