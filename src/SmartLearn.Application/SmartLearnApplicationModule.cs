using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SmartLearn.Authorization;

namespace SmartLearn
{
    [DependsOn(
        typeof(SmartLearnCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SmartLearnApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SmartLearnAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SmartLearnApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
