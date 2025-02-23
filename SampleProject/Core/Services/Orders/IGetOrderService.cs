using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        /// <summary>
        /// Get an order by id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> GetOrderByIdAsync(Guid orderId);

        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetAllAsync();

        /// <summary>
        /// Get orders.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetOrders(Guid? id = null, Guid? productId = null, int? quantity = null, DateTime? orderDate = null);
    }
}
