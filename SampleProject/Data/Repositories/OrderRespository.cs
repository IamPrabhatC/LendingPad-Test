using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    /// <summary>
    /// Repository for managing orders.
    /// </summary>
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class OrderRespository : InMemoryRepository<Order>, IOrderRepository
    {
        /// <summary>
        /// Get orders.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        public Task<IEnumerable<Order>> Get(Guid? id = null, Guid? productId = null,int? quantity = null, DateTime? orderDate = null)
        {          
            
            IQueryable<Order> query = _store.Values.AsQueryable();

            if (id.HasValue)
            {
                query = query.Where(o => o.Id == id.Value);
            }
            if (productId.HasValue)
            {
                query = query.Where(o => o.ProductId == productId.Value);
            }
            if (quantity.HasValue)
            {
                query = query.Where(o => o.Quantity == quantity.Value);
            }
            if (orderDate.HasValue)
            {
                query = query.Where(o => o.OrderDate.Date == orderDate.Value.Date);
            }

            // Return the filtered results
            return Task.FromResult(query.AsEnumerable());
        }

    }
}

