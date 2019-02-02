using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NedbankTest.Authorization;

namespace NedbankTest
{
    [DependsOn(
        typeof(NedbankTestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class NedbankTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<NedbankTestAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(NedbankTestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
