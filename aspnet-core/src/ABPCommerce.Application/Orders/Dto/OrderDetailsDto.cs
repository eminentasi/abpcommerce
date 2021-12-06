using Abp.Application.Services.Dto;
using ABPCommerce.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCommerce.Orders.Dto
{
    public class OrderDetailsDto : EntityDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
