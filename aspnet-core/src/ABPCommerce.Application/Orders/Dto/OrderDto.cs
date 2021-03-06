using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABPCommerce.OrderManagement.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABPCommerce.Orders.Dto
{
    [AutoMap(typeof(Order))]
    public class OrderDto : FullAuditedEntityDto
    {
        public OrderStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        [MaxLength(Order.MaxNotesLength)]
        public string Notes { get; set; }

        public ShippingAddressDto ShippingAddress { get; set; }
        public BillingAddressDto BillingAddress { get; set; }
        public ICollection<OrderDetailsDto> OrderDetails { get; set; }
    }
}
