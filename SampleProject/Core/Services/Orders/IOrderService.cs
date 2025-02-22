﻿using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    /// <summary>
    /// Interface for the order service.
    /// </summary>
    public interface IOrderService
    {

        /// <summary>
        /// Create a new order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<Order> CreateAsync(Guid orderId, Guid productId, int quantity);
        /// <summary>
        /// Update an existing order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<Order> UpdateAsync(Guid orderId, int quantity);
        /// <summary>
        /// Delete an order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid orderId);
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
