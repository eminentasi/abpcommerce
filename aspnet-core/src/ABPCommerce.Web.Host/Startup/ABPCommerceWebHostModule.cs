using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPCommerce.Configuration;

namespace ABPCommerce.Web.Host.Startup
{
    [DependsOn(
       typeof(ABPCommerceWebCoreModule))]
    public class ABPCommerceWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ABPCommerceWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPCommerceWebHostModule).GetAssembly());
        }
    }
}
