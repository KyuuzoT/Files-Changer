using Newtonsoft.Json;

namespace FilesChanger.Localization.Models
{
    internal class LocalizationModel
    {
        [JsonProperty("English")]
        public LanguageModel? EnglishLocale { get; set; }

        [JsonProperty("Russian")]
        public LanguageModel? RussianLocale { get; set; }
    }
}
