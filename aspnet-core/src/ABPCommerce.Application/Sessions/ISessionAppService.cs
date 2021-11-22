using System.Threading.Tasks;
using Abp.Application.Services;
using ABPCommerce.Sessions.Dto;

namespace ABPCommerce.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
