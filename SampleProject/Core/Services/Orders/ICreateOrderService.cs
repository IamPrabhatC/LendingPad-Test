using BusinessEntities;
using System;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    /// <summary>
    /// Interface for creating an order.
    /// </summary>
    public interface ICreateOrderService
    {
        /// <summary>
        /// Create a new order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<Order> CreateAsync(Guid orderId, Guid productId, int quantity);
    }
}
