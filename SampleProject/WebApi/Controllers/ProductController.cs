using Core.Services.Products;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using WebApi.Models.Products;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller for managing products.
    /// </summary>
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{productId:guid}/create")]
        public async Task<HttpResponseMessage> CreateProduct(Guid productId, [FromBody] ProductModel model)
        {
            if (productId == Guid.Empty|| model == null || string.IsNullOrWhiteSpace(model.Name) || model.Price <= 0 || model.Quantity < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid data provided.");
            }
         
            try
            {
                // Check if the product with the given ID already exists
                var existingProduct = await _productService.GetProductByIdAsync(productId);
                if (existingProduct != null)
                {
                    // Return conflict status if the product already exists
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Product with the given ID already exists.");
                }

                var product = await _productService.CreateAsync(productId, model.Name, model.Price, model.Quantity);
                return Request.CreateResponse(HttpStatusCode.Created, product);
            }
            catch (ArgumentException ex)
            {
                // Return validation error if validation fails
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception)
            {
                // Return a general error if product is not found or any other issue
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while creating the product.");
            }
        }

        /// <summary>
        /// Update an existing product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{productId:guid}/update")]
        public async Task<HttpResponseMessage> UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {
            if (model == null || productId == Guid.Empty)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid data provided.");
            }

            try
            {
                // Check if the product with the given ID already exists
                var existingProduct = await _productService.GetProductByIdAsync(productId);
                if (existingProduct == null)
                {
                    // Return NotFound status if the product doesn't exist
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Product with the given ID:{productId} doesnt exists.");
                }
                // Update the product
                var updatedProduct = await _productService.UpdateAsync(productId, model.Name, model.Price, model.Quantity);

                // Return success response
                return Request.CreateResponse(HttpStatusCode.OK, updatedProduct);
            }
            catch (ArgumentException ex)
            {
                // Return validation error if validation fails
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception)
            {
                // Return a general error if product is not found or any other issue                
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while updating the product.");
            }
        }

        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:guid}/delete")]
        public async Task<HttpResponseMessage> DeleteProduct(Guid id)
        {
            // Check if the product with the given ID already exists
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                // Return NotFound status if the product doesn't exist
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Product with the given ID:{id} doesnt exists.");
            }
            await _productService.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Get a product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> GetProduct(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);        

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        /// <summary>
        /// Get products by id, name, price, or quantity.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public async Task<HttpResponseMessage> GetProducts(string name = null, decimal? price = null,  int? quantity = null)
        {
            var products = await _productService.GetProducts(name:name, price: price, quantity: quantity);

            return Request.CreateResponse(HttpStatusCode.OK, products);
        }
    }
}
