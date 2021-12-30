using Abp.Application.Services;
using ABPCommerce.Orders.Dto;

namespace ABPCommerce.Orders
{
    public interface IOrdersAppService : IAsyncCrudAppService<OrderDto, int, PagedOrderResultRequestDto>
    {

    }
}
