using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesChanger
{
    public class FilesPartialChangingHelper
    {
        internal static char PartialReplacementChar = default;
        private static string partialStrContent = default;
        private static bool endOfFileFlag = false;

        private static int bufferSize = 1024 * 1024;

        internal static void PartialChangeFile(FileInfo file)
        {
            char[] buffer = new char[bufferSize];
            using (var sr = new StreamReader(file.FullName))
            {
                int length = 0;
                int maxLength = sr.ReadToEnd().Length;
                using (var bw = new BinaryWriter(File.Open(file.FullName, FileMode.Open)))
                {
                    while (!endOfFileFlag)
                    {
                        buffer = PartialChangeSymbols(sr);

                        PartialWriteSymbols(bw, buffer);

                        length += bufferSize;
                        if (length >= maxLength)
                        {
                            endOfFileFlag = true;
                        }
                    }
                }
            }
        }

        private static char[] PartialChangeSymbols(StreamReader sr)
        {
            char[] buffer = new char[bufferSize];

            sr.ReadBlock(buffer, 0, bufferSize - 1);
            for (int i = 0; i < buffer.Length; i++)
            {
                if(i%2 == 0)
                {
                    buffer[i] = PartialReplacementChar;
                }
            }

            return buffer;
        }

        private static void PartialWriteSymbols(BinaryWriter bw, char[] buffer)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(new string(buffer));
            bw.Write(bytes);
        }
    }
}
