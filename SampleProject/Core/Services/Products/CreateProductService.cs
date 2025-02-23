using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Products
{
    /// <summary>
    /// Service for creating a product.
    /// </summary>
    [AutoRegister(AutoRegisterTypes.Scope)]
    public class CreateProductService:ICreateProductService
    {
        private readonly IProductRepository _productRepository;

        public CreateProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="stockQuantity"></param>
        /// <returns></returns>
        public async Task<Product> CreateAsync(Guid productId, string name, decimal price, int stockQuantity)
        {
            ValidateProduct(productId, name, price, stockQuantity);

            var product = new Product(productId, name, price, stockQuantity);
            await _productRepository.AddAsync(product, product.Id);
            return product;
        }

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
