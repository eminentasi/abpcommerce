using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPCommerce.Authorization;
using ABPCommerce.Categories.Mapping;
using ABPCommerce.Products.Mapping;

namespace ABPCommerce
{
    [DependsOn(
        typeof(ABPCommerceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ABPCommerceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ABPCommerceAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ABPCommerceApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => { 
                    cfg.AddMaps(thisAssembly);
                    ProductDtoMapper.CreateMappings(cfg, new MultiLingualMapContext(
                        IocManager.Resolve<ISettingManager>()
                    ));
                    CategoriesDtoMapper.CreateMappings(cfg, new MultiLingualMapContext(
                        IocManager.Resolve<ISettingManager>()
                    ));
                }
            );
        }
    }
}
