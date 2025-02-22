namespace WebApi.Models.Products
{
    /// <summary>
    /// Model for a product.
    /// </summary>
    public class ProductModel
    {
        
        /// <summary>
        /// Product Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Product Price.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Product Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}