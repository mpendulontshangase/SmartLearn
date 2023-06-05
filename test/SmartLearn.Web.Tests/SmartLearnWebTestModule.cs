using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SmartLearn.EntityFrameworkCore;
using SmartLearn.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace SmartLearn.Web.Tests
{
    [DependsOn(
        typeof(SmartLearnWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SmartLearnWebTestModule : AbpModule
    {
        public SmartLearnWebTestModule(SmartLearnEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SmartLearnWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SmartLearnWebMvcModule).Assembly);
        }
    }
}