using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace ThinkAM.ThinkEvent.Organizations
{
    [Table("AppOrganizationTypes")]
    public class OrganizationType: FullAuditedEntity<int>
    {
        public const int MaxNameLength = 50;

        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }
}
