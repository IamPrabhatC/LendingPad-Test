using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    /// <summary>
    /// Service for updating orders.
    /// </summary>
    [AutoRegister]
    public class UpdateOrderService: IUpdateOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public UpdateOrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Update an existing order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>       
        public async Task<Order> UpdateAsync(Guid orderId, int quantity)
        {
            var order = await _orderRepository.GetAsync(orderId);
            if (order == null) throw new Exception("Order not found.");

            var product = await _productRepository.GetAsync(order.ProductId);
            if (product == null) throw new Exception("Product not found.");

            if (product.Quantity + order.Quantity < quantity) throw new Exception("Not enough stock.");


            product.Quantity += order.Quantity - quantity;
            order.Quantity = quantity;

            return order;
        }
    }
}
