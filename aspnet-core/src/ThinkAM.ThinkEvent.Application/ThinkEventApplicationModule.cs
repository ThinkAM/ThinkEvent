using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ThinkAM.ThinkEvent.Authorization;

namespace ThinkAM.ThinkEvent
{
    [DependsOn(
        typeof(ThinkEventCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ThinkEventApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ThinkEventAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ThinkEventApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
