using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Core.Services.Products
{
    /// <summary>
    /// Service for updating a product.
    /// </summary>
    [AutoRegister(AutoRegisterTypes.Scope)]
    public class UpdateProductService:IUpdateProductService
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        ///  Update an existing product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>        
        public async Task<Product> UpdateAsync(Guid productId, string name, decimal price, int quantity)
        {
            ValidateProduct(productId, name, price, quantity);
            var product = await _productRepository.GetAsync(productId);
            if (product == null) throw new Exception("Product not found.");

            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;

            return product;
        }


        /// <summary>
        /// Validate the product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <exception cref="ArgumentException"></exception>
        internal void ValidateProduct(Guid productId, string name, decimal price, int quantity)
        {
            // Validate the product ID
            if (productId == Guid.Empty)
            {
                throw new ArgumentException("Product ID cannot be empty.", nameof(productId));
            }
            // Validate the product name
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be empty.", nameof(name));
            }
            // Validate the price
            if (price <= 0)
            {
                throw new ArgumentException("Price must be a positive value.", nameof(price));
            }
            // Validate the quantity
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));
            }
        }

    }
}
