using System.Threading.Tasks;
using Abp.Application.Services;
using ABPCommerce.Authorization.Accounts.Dto;

namespace ABPCommerce.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
