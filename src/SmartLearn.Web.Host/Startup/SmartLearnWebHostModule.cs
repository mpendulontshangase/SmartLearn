using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SmartLearn.Configuration;

namespace SmartLearn.Web.Host.Startup
{
    [DependsOn(
       typeof(SmartLearnWebCoreModule))]
    public class SmartLearnWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SmartLearnWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SmartLearnWebHostModule).GetAssembly());
        }
    }
}
