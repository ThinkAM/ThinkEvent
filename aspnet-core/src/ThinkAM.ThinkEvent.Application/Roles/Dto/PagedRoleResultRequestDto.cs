using Abp.Application.Services.Dto;

namespace ThinkAM.ThinkEvent.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

