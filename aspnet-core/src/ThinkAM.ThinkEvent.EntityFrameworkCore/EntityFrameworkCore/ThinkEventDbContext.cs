using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;

namespace ThinkAM.ThinkEvent.EntityFrameworkCore
{
    using Authorization.Roles;
    using Authorization.Users;
    using MultiTenancy;
    using Organizations;

    public class ThinkEventDbContext : AbpZeroDbContext<Tenant, Role, User, ThinkEventDbContext>
    {
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        
        public ThinkEventDbContext(DbContextOptions<ThinkEventDbContext> options)
            : base(options)
        {
        }
    }
}
