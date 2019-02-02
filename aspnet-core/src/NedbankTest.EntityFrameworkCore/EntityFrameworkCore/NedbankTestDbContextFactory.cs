using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NedbankTest.Configuration;
using NedbankTest.Web;

namespace NedbankTest.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class NedbankTestDbContextFactory : IDesignTimeDbContextFactory<NedbankTestDbContext>
    {
        public NedbankTestDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NedbankTestDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            NedbankTestDbContextConfigurer.Configure(builder, configuration.GetConnectionString(NedbankTestConsts.ConnectionStringName));

            return new NedbankTestDbContext(builder.Options);
        }
    }
}
