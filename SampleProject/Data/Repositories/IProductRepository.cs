using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    /// <summary>
    /// Interface for the Product Repository
    /// </summary>
    public interface IProductRepository: IInMemoryRepository<Product>
    {
        /// <summary>
        /// Get a product by name, price, or quantity.   
        /// </summary>
        /// <param id="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> Get(Guid? id = null, string name = null, decimal? price = null, int? quantity = null);
    }  
}
