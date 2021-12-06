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
    public class OrdersAppService : ApplicationService, IOrdersAppService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrdersAppService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ListResultDto<OrderListDto>> GetAll()
        {
            var orders = await _orderRepository.GetAll().ToListAsync();
            return new ListResultDto<OrderListDto>(ObjectMapper.Map<List<OrderListDto>>(orders));
        }
        public async Task<OrderDto> Get(int id)
        {
            var order = await _orderRepository.GetAll()
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(p => p.Id == id);

            return ObjectMapper.Map<OrderDto>(order);
        }

        public async Task Create(OrderDto input)
        {
            var order = ObjectMapper.Map<Order>(input);
            await _orderRepository.InsertAsync(order);
        }

        public async Task Update(OrderDto input)
        {
            var order = await _orderRepository.GetAllIncluding(o => o.OrderDetails)
                .FirstOrDefaultAsync(p => p.Id == input.Id);

            ObjectMapper.Map(input, order);
        }

        public async Task Delete(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
