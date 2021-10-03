using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;

namespace ThinkAM.ThinkEvent.Organizations
{
    using Dto;

    [AbpAuthorize]
    public class OrganizationTypeAppService: AsyncCrudAppService<OrganizationType, OrganizationTypeDto, int, PagedResultRequestDto, CreateOrganizationTypeDto, OrganizationTypeDto>, IOrganizationTypeAppService
    {
        public OrganizationTypeAppService(IRepository<OrganizationType, int> organizationTypeRepository) 
            :base(organizationTypeRepository)
        {
            
        }
    }
}
