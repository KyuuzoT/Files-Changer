using FilesChanger.Localization.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<LocalizedStringModel> GetLocalizedStrings()
        {
            var model = GetLocalizationModelFromJson();

            var currentLocale = currentLanguage switch
            {
                AvailableLanguages.Russian => model.RussianLocale,
                AvailableLanguages.English => model.EnglishLocale,
                _ => model.EnglishLocale
            } 
            ?? throw new Exception("Application was unable to locate language.");

            return currentLocale.LocalizedStrings ?? throw new Exception("Current localization contains no language-specific strings.");
        }

        private LocalizationModel GetLocalizationModelFromJson()
        {
            string json = string.Empty;
            return JsonConvert.DeserializeObject<LocalizationModel>(json);
        }

    }
}
