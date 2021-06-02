using System.Threading.Tasks;
using ThinkAM.ThinkEvent.Configuration.Dto;

namespace ThinkAM.ThinkEvent.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
