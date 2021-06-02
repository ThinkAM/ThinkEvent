using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ThinkAM.ThinkEvent.MultiTenancy;

namespace ThinkAM.ThinkEvent.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
