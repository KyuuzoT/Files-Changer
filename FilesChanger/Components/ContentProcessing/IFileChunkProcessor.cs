namespace FilesChanger.Components.ContentProcessing
{
    public interface IFileChunkProcessor
    {
        char[] ProcessChunk(char[] chunk);
    }
}
