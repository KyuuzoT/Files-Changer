using FilesChanger.Localization.Models;
using Newtonsoft.Json;

namespace FilesChanger.Localization
{
    internal class LocalizationHandler
    {
        private readonly AvailableLanguages currentLanguage;

        private LocalizationHandler()
        {
            currentLanguage = AvailableLanguages.English;
        }

        public LocalizationHandler(string language)
        {
            currentLanguage = language.ToLower() switch
            {
                "russian" or "ru" or "ru-ru" => AvailableLanguages.Russian,
                _ => AvailableLanguages.English,
            };
        }

        public LocalizationHandler(AvailableLanguages language)
        {
            currentLanguage = language;
        }

        public LocalizedStringModel GetElement(string elementName)
        {
            var locStrings = GetLocalizedStrings();

            var element = locStrings.FirstOrDefault(x => x?.Element != null && x.Element.Equals(elementName));

            return element ?? throw new NullReferenceException("An element with such name was not found or localization does not contain elements");
        }

        private IEnumerable<LocalizedStringModel> GetLocalizedStrings()
        {
            var model = GetLocalizationModelFromJson();

            var language = GetLanguage(model);

            return language.LocalizedStrings ?? [];
        }

        private LocalizationModel GetLocalizationModelFromJson()
        {
            var localizationFileName = currentLanguage switch
            {
                AvailableLanguages.English => "en-EN",
                AvailableLanguages.Russian => "ru-RU",
                _ => "en-EN"
            };

            string json = File.ReadAllText(Path.GetFullPath($"./Localization/Languages/{localizationFileName}.json"));
            return JsonConvert.DeserializeObject<LocalizationRootModel>(json)?.Localization ??
                throw new NullReferenceException("Localization file not found or malformed.");
        }

        private LanguageModel GetLanguage(LocalizationModel model)
        {
            if(model.RussianLocale == null && model.EnglishLocale != null)
            {
                return model.EnglishLocale;
            }

            if (model.EnglishLocale == null && model.RussianLocale != null)
            {
                return model.RussianLocale;
            }

            throw new NullReferenceException("Unable to locate acceptable language. Probably not found or malformed localization file.");
        }
    }
}
