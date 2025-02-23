using BusinessEntities;
using System;
using System.Threading.Tasks;

namespace Core.Services.Products
{
    /// <summary>
    /// Interface for creating a product.
    /// </summary>
    public interface ICreateProductService
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
    }
}
