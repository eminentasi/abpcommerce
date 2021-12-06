using Abp.Application.Services.Dto;
using ABPCommerce.Orders.Dto;
using System.Threading.Tasks;

namespace ABPCommerce.Orders
{
    interface IOrdersAppService
    {
        Task<ListResultDto<OrderListDto>> GetAll();
        Task<OrderDto> Get(int id);
        Task Create(OrderDto input);
        Task Update(OrderDto input);
        Task Delete(int id);
    }
}
