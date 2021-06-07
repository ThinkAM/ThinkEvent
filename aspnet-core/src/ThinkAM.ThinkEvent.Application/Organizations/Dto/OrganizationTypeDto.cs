using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ThinkAM.ThinkEvent.Organizations.Dto
{
    [AutoMap(typeof(OrganizationType))]
    public class OrganizationTypeDto: FullAuditedEntityDto<int>
    {
        [StringLength(OrganizationType.MaxNameLength)]
        public string Name { get; set; }
    }
}
