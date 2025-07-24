using FilesChanger.Components.Utilities;

namespace FilesChanger.Components.ContentProcessing
{
    public class FilePartialChanger
    {
        private readonly IFileChunkProcessor _processor;
        private readonly ChunkedFileReader _reader;
        private readonly ChunkedFileWriter _writer;
        private readonly RetryPolicy _retryPolicy;

        public FilePartialChanger(
            IFileChunkProcessor processor,
            ChunkedFileReader reader,
            ChunkedFileWriter writer,
            RetryPolicy retryPolicy)
        {
            _processor = processor;
            _reader = reader;
            _writer = writer;
            _retryPolicy = retryPolicy;
        }

        public void ChangeFile(FileInfo file)
        {
            _retryPolicy.Execute(() =>
            {
                var processedChunks = _reader.ReadChunks(file)
                    .Select(chunk => _processor.ProcessChunk(chunk))
                    .ToList();

                _writer.WriteChunks(file, processedChunks);
            });
        }
    }
}
