using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Products
{
    /// <summary>
    /// Class for deleting a product.
    /// </summary>
    [AutoRegister(AutoRegisterTypes.Scope)]
    public class DeleteProductService:IDeleteProductService
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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
    }
}
