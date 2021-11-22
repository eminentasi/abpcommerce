using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ABPCommerce.Localization
{
    public static class ABPCommerceLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ABPCommerceConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ABPCommerceLocalizationConfigurer).GetAssembly(),
                        "ABPCommerce.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
