using Abp.Application.Services;
using ThinkAM.ThinkEvent.MultiTenancy.Dto;

namespace ThinkAM.ThinkEvent.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

