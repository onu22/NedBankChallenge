using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace NedbankTest.EntityFrameworkCore
{
    public static class NedbankTestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NedbankTestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NedbankTestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
