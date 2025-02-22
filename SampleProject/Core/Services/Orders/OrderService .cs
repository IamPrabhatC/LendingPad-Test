using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    /// <summary>
    /// Service for managing orders.
    /// </summary>
    [AutoRegister(AutoRegisterTypes.Scope)]
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
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
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Update an existing order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Delete an order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <summary>
        /// Get an order by id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            return _orderRepository.GetAsync(orderId);
        }

        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Order>> GetAllAsync()
        {
            return _orderRepository.GetAllAsync();
        }

        /// <summary>
        /// Get orders by id, productId, quantity, or orderDate.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        public Task<IEnumerable<Order>> GetOrders(Guid? id = null, Guid? productId = null, int? quantity = null, DateTime? orderDate = null)
        {
            return _orderRepository.Get(id, productId, quantity, orderDate);
        }
    }
}
