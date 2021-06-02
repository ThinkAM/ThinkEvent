using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ThinkAM.ThinkEvent.Localization
{
    public static class ThinkEventLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ThinkEventConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ThinkEventLocalizationConfigurer).GetAssembly(),
                        "ThinkAM.ThinkEvent.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
