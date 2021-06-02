using Abp.AutoMapper;
using ThinkAM.ThinkEvent.Authentication.External;

namespace ThinkAM.ThinkEvent.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
