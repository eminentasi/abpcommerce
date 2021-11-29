using Abp.Domain.Entities;
using ABPCommerce.Catalog.Product;

namespace ABPCommerce.OrderManagement.Order
{
    public class OrderDetails : Entity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
