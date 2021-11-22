using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ABPCommerce.Configuration.Dto;

namespace ABPCommerce.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ABPCommerceAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
