using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ThinkAM.ThinkEvent.EntityFrameworkCore;
using ThinkAM.ThinkEvent.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ThinkAM.ThinkEvent.Web.Tests
{
    [DependsOn(
        typeof(ThinkEventWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ThinkEventWebTestModule : AbpModule
    {
        public ThinkEventWebTestModule(ThinkEventEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ThinkEventWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ThinkEventWebMvcModule).Assembly);
        }
    }
}