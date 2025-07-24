using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesChanger.Components.ContentProcessing
{
    public class ChunkedFileReader
    {
        private readonly int _chunkSize;

        public ChunkedFileReader(int chunkSize)
        {
            _chunkSize = chunkSize;
        }

        public IEnumerable<char[]> ReadChunks(FileInfo file)
        {
            using var reader = new StreamReader(file.FullName);
            char[] buffer = new char[_chunkSize];

            int read;
            while ((read = reader.ReadBlock(buffer, 0, _chunkSize)) > 0)
            {
                yield return buffer[..read]; // Only return the filled portion
            }
        }
    }
}
