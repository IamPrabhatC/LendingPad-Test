using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{

    /// <summary>
    /// Repository for managing products.
    /// </summary>
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class ProductRepository : InMemoryRepository<Product>, IProductRepository 
    {
        /// <summary>
        /// Get Products by id, name, price, or quantity. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>        
        public Task<IEnumerable<Product>> Get(Guid? id = null, string name = null, decimal? price = null, int? quantity = null)
        {
            var query = _store.Values.AsQueryable();

            if (id.HasValue)
            {
                query = query.Where(p => p.Id == id.Value);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }

            if (price.HasValue)
            {
                query = query.Where(p => p.Price == price.Value);
            }

            if (quantity.HasValue)
            {
                query = query.Where(p => p.Quantity == quantity.Value);
            }

            return Task.FromResult<IEnumerable<Product>>(query.ToList());
        }
    }
}
