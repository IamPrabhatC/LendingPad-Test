using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Products
{
    /// <summary>
    /// Interface for getting a product.
    /// </summary>
    public interface IGetProductService
    {
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
