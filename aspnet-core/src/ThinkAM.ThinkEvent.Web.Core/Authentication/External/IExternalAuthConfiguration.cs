using System.Collections.Generic;

namespace ThinkAM.ThinkEvent.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
