using Core.Services.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApi.Models.Orders;
using BusinessEntities;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller for managing orders.
    /// </summary>
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Create a new order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{orderId:guid}/create")]
        public async Task<HttpResponseMessage> CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            if (orderId == null || model == null || model.Quantity <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid data provided.");
            }
    
            try
            {
                // Check if the order with the given ID already exists
                var existingOrder = await _orderService.GetOrderByIdAsync(orderId);
                if (existingOrder != null)
                {
                    // Return conflict status if the order already exists
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, $"Order with the given ID:{orderId} already exists.");
                }

                var order = await _orderService.CreateAsync(orderId, model.ProductId, model.Quantity);
                return Request.CreateResponse(HttpStatusCode.Created, order);
            }
            catch (ArgumentException ex)
            {
                // Return validation error if validation fails
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception)
            {
                // Return a general error if order is not found or any other issue
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while creating the order.");
            }
        }

        /// <summary>
        /// Update an existing order.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:guid}/update")]
        public async Task<HttpResponseMessage> UpdateOrder(Guid id, [FromBody] OrderModel model)
        {
            if (model == null || model.Quantity <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid data provided.");
            }
            
            try
            {
                // Check if the order with the given ID already exists
                var existingOrder = await _orderService.GetOrderByIdAsync(id);
                if (existingOrder == null)
                {
                    // Return NotFound status if the order doesn't exist
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Order with the given ID:{id} doesnt exists.");
                }

                var order = await _orderService.UpdateAsync(id, model.Quantity);
                return Request.CreateResponse(HttpStatusCode.OK, order);
            }
            catch (ArgumentException ex)
            {
                // Return validation error if validation fails
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception)
            {
                // Return a general error if order is not found or any other issue
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while updating the order.");
            }
        }

        /// <summary>
        /// Delete an order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:guid}/delete")]
        public async Task<HttpResponseMessage> DeleteOrder(Guid id)
        {
            // Check if the order with the given ID already exists
            var existingOrder = await _orderService.GetOrderByIdAsync(id);
            if (existingOrder == null)
            {
                // Return NotFound status if the order doesn't exist
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Order with the given ID:{id} doesnt exists.");
            }
            await _orderService.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Get an order by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Order not found.");

            return Request.CreateResponse(HttpStatusCode.OK, order);
        }

        /// <summary>
        /// Get  orders.
        /// </summary>        
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public async Task<HttpResponseMessage> GetOrders(Guid? productId = null, int? quantity = null, DateTime? orderDate = null)
        {
            var orders = await _orderService.GetOrders(productId: productId,quantity: quantity, orderDate: orderDate);
            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }
    }
}