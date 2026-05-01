namespace FilesChanger.Localization.Models
{
    internal class LocalizedStringModel
    {
        public string? Element { get; set; }
        public string? TextMain { get; set; }
        public IEnumerable<string>? TextVariants { get; set; }
    }
}
