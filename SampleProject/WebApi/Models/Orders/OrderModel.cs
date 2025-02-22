using System;

namespace WebApi.Models.Orders
{
    /// <summary>
    /// Order model.
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// Product id.
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// Quantity of product.
        /// </summary>
        public int Quantity { get; set; }
    }
}