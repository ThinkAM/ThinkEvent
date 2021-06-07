using System;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace ThinkAM.ThinkEvent.Organizations
{
    using Dto;

    public class OrganizationTypeAppService: AsyncCrudAppService<OrganizationType, OrganizationTypeDto, int, PagedResultRequestDto, CreateOrganizationTypeDto, OrganizationTypeDto>, IOrganizationTypeAppService
    {
        public OrganizationTypeAppService(IRepository<OrganizationType, int> organizationTypeRepository) 
            :base(organizationTypeRepository)
        {
            
        }
    }
}
