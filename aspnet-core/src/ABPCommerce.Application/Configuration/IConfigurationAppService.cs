using System.Threading.Tasks;
using ABPCommerce.Configuration.Dto;

namespace ABPCommerce.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
