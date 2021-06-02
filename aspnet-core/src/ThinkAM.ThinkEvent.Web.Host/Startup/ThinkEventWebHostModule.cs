using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ThinkAM.ThinkEvent.Configuration;

namespace ThinkAM.ThinkEvent.Web.Host.Startup
{
    [DependsOn(
       typeof(ThinkEventWebCoreModule))]
    public class ThinkEventWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ThinkEventWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ThinkEventWebHostModule).GetAssembly());
        }
    }
}
