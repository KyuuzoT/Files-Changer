namespace FilesChanger.Components.ContentProcessing
{
    public class PartialSymbolReplacer : IFileChunkProcessor
    {
        private readonly char _replacementChar;

        public PartialSymbolReplacer(char replacementChar)
        {
            _replacementChar = replacementChar;
        }

        public char[] ProcessChunk(char[] chunk)
        {
            var result = new char[chunk.Length];
            for (int i = 0; i < chunk.Length; i++)
            {
                result[i] = i % 2 == 0 ? _replacementChar : chunk[i];
            }
            return result;
        }
    }
}
