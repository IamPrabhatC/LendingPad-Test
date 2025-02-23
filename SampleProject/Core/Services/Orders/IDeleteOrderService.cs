using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    /// <summary>
    /// Interface for deleting an order.
    /// </summary>
    public interface IDeleteOrderService
    {
        /// <summary>
        /// Delete an order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid orderId);
    }
}
