using System;
using System.IO;
using System.Text;

namespace FilesChanger.Components.ContentProcessing
{
    public sealed class FilePartialProcessor : IDisposable
    {
        private const int MaxRetries = 5;
        private const int BufferSize = 128 * 1024; // 128 KB
        private readonly byte[] _buffer = new byte[BufferSize];
        private readonly char _replacementChar;
        private readonly Encoding _encoding;
        private FileStream? _fileStream;

        public FilePartialProcessor(char replacementChar, Encoding encoding)
        {
            _replacementChar = replacementChar;
            _encoding = encoding;
        }

        public void ProcessFile(FileInfo file)
        {
            ArgumentNullException.ThrowIfNull(file);

            try
            {
                _fileStream = new FileStream(
                    file.FullName,
                    FileMode.Open,
                    FileAccess.ReadWrite,
                    FileShare.Read,
                    BufferSize,
                    FileOptions.RandomAccess
                );

                ProcessFileContents();
            }
            finally
            {
                Dispose();
            }
        }

        private void ProcessFileContents()
        {
            long totalBytes = _fileStream!.Length;
            long totalProcessed = 0;
            int retryCount = 0;

            while (totalProcessed < totalBytes)
            {
                try
                {
                    int bytesRead = ReadChunk(totalProcessed);
                    ProcessChunk(bytesRead, totalProcessed);
                    WriteChunk(bytesRead, totalProcessed);

                    totalProcessed += bytesRead;
                    retryCount = 0; // Reset retry counter after success
                }
                catch (Exception ex) when (retryCount < MaxRetries)
                {
                    retryCount++;
                    Console.Error.WriteLine($"Attempt {retryCount} failed: {ex.Message}");
                }
            }
        }

        private int ReadChunk(long position)
        {
            _fileStream!.Seek(position, SeekOrigin.Begin);
            return _fileStream.Read(_buffer, 0, BufferSize);
        }

        private void ProcessChunk(int bytesRead, long globalPosition)
        {
            string chunk = _encoding.GetString(_buffer, 0, bytesRead);
            char[] chars = chunk.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                // Use global position for consistent replacement
                if ((globalPosition + i) % 2 == 0)
                {
                    chars[i] = _replacementChar;
                }
            }

            byte[] processedBytes = _encoding.GetBytes(chars);
            Buffer.BlockCopy(processedBytes, 0, _buffer, 0, processedBytes.Length);
        }

        private void WriteChunk(int bytesRead, long position)
        {
            _fileStream!.Seek(position, SeekOrigin.Begin);
            _fileStream.Write(_buffer, 0, bytesRead);
        }

        public void Dispose()
        {
            _fileStream?.Dispose();
            _fileStream = null;
        }
    }
}