using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Products
{
    /// <summary>
    /// Service for managing products.
    /// </summary>
    [AutoRegister(AutoRegisterTypes.Scope)]
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
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

        /// <summary>
        ///  Update an existing product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(Guid productId)
        {
            if (!await _productRepository.ExistsAsync(productId)) throw new Exception("Product not found.");
            await _productRepository.RemoveAsync(productId);
        }

        /// <summary>
        /// Get a product by id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Task<Product> GetProductByIdAsync(Guid productId)
        {
            return _productRepository.GetAsync(productId);
        }

        /// <summary>
        /// Get products by name, price, and quantity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Task<IEnumerable<Product>> GetProducts(Guid? id = null, string name = null, decimal? price = null, int? quantity = null)
        {
            return  _productRepository.Get(id, name, price, quantity);
        }
    }
}

