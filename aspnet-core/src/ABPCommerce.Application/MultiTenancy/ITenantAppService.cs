using Abp.Application.Services;
using ABPCommerce.MultiTenancy.Dto;

namespace ABPCommerce.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

