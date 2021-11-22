using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPCommerce.EntityFrameworkCore;
using ABPCommerce.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ABPCommerce.Web.Tests
{
    [DependsOn(
        typeof(ABPCommerceWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ABPCommerceWebTestModule : AbpModule
    {
        public ABPCommerceWebTestModule(ABPCommerceEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPCommerceWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ABPCommerceWebMvcModule).Assembly);
        }
    }
}