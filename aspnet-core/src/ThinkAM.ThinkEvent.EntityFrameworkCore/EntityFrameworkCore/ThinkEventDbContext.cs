using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ThinkAM.ThinkEvent.Authorization.Roles;
using ThinkAM.ThinkEvent.Authorization.Users;
using ThinkAM.ThinkEvent.MultiTenancy;

namespace ThinkAM.ThinkEvent.EntityFrameworkCore
{
    public class ThinkEventDbContext : AbpZeroDbContext<Tenant, Role, User, ThinkEventDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ThinkEventDbContext(DbContextOptions<ThinkEventDbContext> options)
            : base(options)
        {
        }
    }
}
