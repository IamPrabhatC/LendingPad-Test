using System;

namespace BusinessEntities
{
    /// <summary>
    /// Product entity
    /// </summary>
    public class Product
    {
        /// <summary>
        /// product id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// product name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// product price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// product quantity
        /// </summary>
        public int Quantity { get; set; }

        public Product(Guid productId, string name, decimal price, int quantity)
        {
            Id = productId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
