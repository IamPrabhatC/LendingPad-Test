using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Products
{
    /// <summary>
    /// Interface for updating a product.
    /// </summary>
    public interface IUpdateProductService
    {
        /// <summary>
        /// Update an existing product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<Product> UpdateAsync(Guid productId, string name, decimal price, int quantity);
    }
}
