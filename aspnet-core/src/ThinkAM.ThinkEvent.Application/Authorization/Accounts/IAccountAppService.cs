using System.Threading.Tasks;
using Abp.Application.Services;
using ThinkAM.ThinkEvent.Authorization.Accounts.Dto;

namespace ThinkAM.ThinkEvent.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
