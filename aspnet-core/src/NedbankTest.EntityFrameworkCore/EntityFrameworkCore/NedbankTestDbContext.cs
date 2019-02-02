using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NedbankTest.Authorization.Roles;
using NedbankTest.Authorization.Users;
using NedbankTest.MultiTenancy;
using NedbankTest.Calls;

namespace NedbankTest.EntityFrameworkCore
{
    public class NedbankTestDbContext : AbpZeroDbContext<Tenant, Role, User, NedbankTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Call> Calls { get; set; }
        public NedbankTestDbContext(DbContextOptions<NedbankTestDbContext> options)
            : base(options)
        {
        }
    }
}
