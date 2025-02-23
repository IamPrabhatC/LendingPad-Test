using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    /// <summary>
    /// Interface for updating an order.
    /// </summary>
    public interface IUpdateOrderService
    {
        /// <summary>
        /// Update an existing order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<Order> UpdateAsync(Guid orderId, int quantity);
    }
}
