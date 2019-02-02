using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NedbankTest.Configuration;

namespace NedbankTest.Web.Host.Startup
{
    [DependsOn(
       typeof(NedbankTestWebCoreModule))]
    public class NedbankTestWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public NedbankTestWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NedbankTestWebHostModule).GetAssembly());
        }
    }
}
