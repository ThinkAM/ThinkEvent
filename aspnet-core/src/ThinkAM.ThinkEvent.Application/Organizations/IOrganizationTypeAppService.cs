using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace ThinkAM.ThinkEvent.Organizations
{
    using Dto;

    public interface IOrganizationTypeAppService: IAsyncCrudAppService<OrganizationTypeDto, int, PagedResultRequestDto, CreateOrganizationTypeDto, OrganizationTypeDto>
    {
         
    }
}