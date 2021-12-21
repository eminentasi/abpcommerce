using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABPCommerce.OrderManagement.Order;
using System;
using System.Collections.Generic;

namespace ABPCommerce.Orders.Dto
{
    [AutoMap(typeof(Order))]
    public class OrderDto : FullAuditedEntityDto
    {
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

        public ShippingAddressDto ShippingAddress { get; set; }
        public BillingAddressDto BillingAddress { get; set; }
        public ICollection<OrderDetailsDto> OrderDetails { get; set; }
    }
}
