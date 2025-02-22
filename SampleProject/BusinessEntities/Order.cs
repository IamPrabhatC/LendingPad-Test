using System;

namespace BusinessEntities
{
    /// <summary>
    /// Order entity
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Product id
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// Quantity of product
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Order date
        /// </summary>
        public DateTime OrderDate { get; set; }

        public Order(Guid orderId, Guid productId, int quantity)
        {
            Id = orderId;
            ProductId = productId;
            Quantity = quantity;
            OrderDate = DateTime.UtcNow;
        }
    }
}
