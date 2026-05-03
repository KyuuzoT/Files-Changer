using Newtonsoft.Json;

namespace FilesChanger.Localization.Models
{
    internal class LanguageModel
    {
        [JsonProperty("Strings")]
        public IEnumerable<LocalizedStringModel>? LocalizedStrings { get; set; }
    }
}
