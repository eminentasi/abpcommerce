using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ABPCommerce.Authorization;
using ABPCommerce.OrderManagement.Order;
using ABPCommerce.Orders.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ABPCommerce.Orders
{
    [AbpAuthorize(PermissionNames.Pages_Orders)]
    public class OrdersAppService : AsyncCrudAppService<Order, OrderDto, int, PagedOrderResultRequestDto>, IOrdersAppService
    {
        public OrdersAppService(IRepository<Order> repository)
            : base(repository)
        {

        }

        public override async Task<OrderDto> GetAsync(EntityDto<int> input)
        {
            CheckGetPermission();
            var order = await Repository.GetAll()
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(p => p.Id == input.Id);

            return ObjectMapper.Map<OrderDto>(order);
        }
    }
}

