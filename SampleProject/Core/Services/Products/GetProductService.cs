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
    /// Service for fetching products.
    /// </summary>
    [AutoRegister(AutoRegisterTypes.Scope)]
    public class GetProductService: IGetProductService
    {
        private readonly IProductRepository _productRepository;
        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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
            return _productRepository.Get(id, name, price, quantity);
        }
    }
}
