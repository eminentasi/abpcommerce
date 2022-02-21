using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABPCommerce.OrderManagement.Order
{
    public class Order : FullAuditedEntity
    {
        public const int MaxNotesLength = 500;

        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        [MaxLength(MaxNotesLength)]
        public string Notes { get; set; }
        public Shipping.ShippingAddress ShippingAddress { get; set; }
        public Billing.BillingAddress BillingAddress { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
