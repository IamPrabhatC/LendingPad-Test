using Common;
using Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    /// <summary>
    /// Service for deleting an order.
    /// </summary>
    [AutoRegister]
    public class DeleteOrderService:IDeleteOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public DeleteOrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Delete an order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>        
        public async Task DeleteAsync(Guid orderId)
        {
            var order = await _orderRepository.GetAsync(orderId);
            if (order == null) throw new Exception("Order not found.");

            var product = await _productRepository.GetAsync(order.ProductId);
            if (product != null)
            {
                /// Increase stock quantity
                product.Quantity += order.Quantity;
            }

            await _orderRepository.RemoveAsync(orderId);
        }
    }
}
