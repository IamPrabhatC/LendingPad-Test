using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Products
{
    /// <summary>
    /// Interface for deleting a product.
    /// </summary>
    public interface IDeleteProductService
    {
        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid productId);
    }
}
