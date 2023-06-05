using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace SmartLearn.Localization
{
    public static class SmartLearnLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SmartLearnConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SmartLearnLocalizationConfigurer).GetAssembly(),
                        "SmartLearn.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
