using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Products
{
    /// <summary>
    /// Interface for the product service.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<Product> CreateAsync(Guid productId, string name, decimal price, int quantity);
        /// <summary>
        /// Update an existing product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<Product> UpdateAsync(Guid productId, string name, decimal price, int quantity);
        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid productId);
        /// <summary>
        /// Get a product by id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(Guid productId);


        /// <summary>
        /// Get products by id, name, price, or quantity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProducts(Guid? id = null, string name = null, decimal? price = null, int? quantity = null);
    }
}
