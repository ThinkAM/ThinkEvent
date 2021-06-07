using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using System;

namespace ThinkAM.ThinkEvent.Organizations.Dto
{
    [AutoMapTo(typeof(OrganizationType))]
    public class CreateOrganizationTypeDto
    {
        [StringLength(OrganizationType.MaxNameLength)]
        public string Name { get; set; }
    }
}
