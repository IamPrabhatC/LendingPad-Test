using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    /// <summary>
    /// Class for creating an order.
    /// </summary>
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Create a new order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>        
        public async Task<Order> CreateAsync(Guid orderId, Guid productId, int quantity)
        {
            var product = await _productRepository.GetAsync(productId);
            if (product == null) throw new Exception("Product not found.");

            if (product.Quantity < quantity) throw new Exception("Not enough stock.");

            var order = new Order(orderId, productId, quantity);
            await _orderRepository.AddAsync(order, order.Id);

            product.Quantity -= quantity;  // Decrease stock quantity
            return order;
        }
    }
}
