using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ThinkAM.ThinkEvent.Configuration;
using ThinkAM.ThinkEvent.EntityFrameworkCore;
using ThinkAM.ThinkEvent.Migrator.DependencyInjection;

namespace ThinkAM.ThinkEvent.Migrator
{
    [DependsOn(typeof(ThinkEventEntityFrameworkModule))]
    public class ThinkEventMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ThinkEventMigratorModule(ThinkEventEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ThinkEventMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ThinkEventConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ThinkEventMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
