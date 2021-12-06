﻿using Abp.Application.Services.Dto;
using ABPCommerce.OrderManagement.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCommerce.Orders.Dto
{
    public class OrderListDto : FullAuditedEntityDto
    {
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

    }
}