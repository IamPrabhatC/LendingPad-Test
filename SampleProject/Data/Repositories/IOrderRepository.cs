using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    /// <summary>
    /// Interface for Order Repository
    /// </summary>
    public interface IOrderRepository:IInMemoryRepository<Order>
    {
        /// <summary>
        /// Get orders.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> Get(Guid? id = null, Guid? productId = null, int? quantity = null, DateTime? orderDate = null);
    }
}
