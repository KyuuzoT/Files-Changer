using System.Text;

namespace FilesChanger.Components.ContentProcessing
{
    public class ChunkedFileWriter
    {
        public void WriteChunks(FileInfo file, IEnumerable<char[]> chunks)
        {
            using var stream = File.Open(file.FullName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            using var writer = new BinaryWriter(stream, Encoding.ASCII);

            foreach (var chunk in chunks)
            {
                var bytes = Encoding.ASCII.GetBytes(chunk);
                writer.Write(bytes);
            }
        }
    }
}
