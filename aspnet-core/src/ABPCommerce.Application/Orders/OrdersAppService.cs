using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ABPCommerce.OrderManagement.Order;
using ABPCommerce.Orders.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCommerce.Orders
{
    public class OrdersAppService : AsyncCrudAppService<Order, OrderDto, int, PagedOrderResultRequestDto>, IOrdersAppService
    {
        public OrdersAppService(IRepository<Order> repository)
            : base(repository)
        {
            
        }

        public override async Task<OrderDto> GetAsync(EntityDto<int> input)
        {
            var order = await Repository.GetAll()
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(p => p.Id == input.Id);

            return ObjectMapper.Map<OrderDto>(order);
        }
    }
}
