using System.Threading.Tasks;
using Abp.Application.Services;
using ThinkAM.ThinkEvent.Sessions.Dto;

namespace ThinkAM.ThinkEvent.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
