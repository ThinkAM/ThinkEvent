using Abp.MultiTenancy;
using ThinkAM.ThinkEvent.Authorization.Users;

namespace ThinkAM.ThinkEvent.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
