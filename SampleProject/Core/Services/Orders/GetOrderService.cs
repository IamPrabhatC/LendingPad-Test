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
    /// Service for fetching orders.
    /// </summary>
    [AutoRegister]
    public class GetOrderService:IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public GetOrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
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
