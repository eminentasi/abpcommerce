using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace ABPCommerce.OrderManagement.Order
{
    public class Order : FullAuditedEntity
    {
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
