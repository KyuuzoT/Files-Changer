using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesChanger
{
    public class FilesChangingHelper
    {
        internal static char ReplacementChar = default;
        private static string strContent = string.Empty;
        private static char[] signsArray = default;

        internal static void ChangeFile(FileInfo file)
        {
            using (var sr = new StreamReader(file.FullName))
            {
                //ChangeFileContentSymbols(sr);
                ChangeFileContentSymbolsInBlocks(sr);
            }

            //WriteSymbolsToFile(file);
            WriteSymbolsToFileFromString(file);
            strContent = string.Empty;
        }

        private static void WriteSymbolsToFile(FileInfo file)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(new string(signsArray));
            using (var bw = new BinaryWriter(File.Open(file.FullName, FileMode.Open)))
            {
                bw.Write(bytes);
            }
        }
        
        private static void WriteSymbolsToFileFromString(FileInfo file)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(strContent);
            using (var bw = new BinaryWriter(File.Open(file.FullName, FileMode.Open)))
            {
                bw.Write(bytes);
            }
        }

        private static void ChangeFileContentSymbols(StreamReader sr)
        {
            signsArray = default;
            strContent = sr.ReadToEnd();
            signsArray = strContent.ToArray();

            for (int i = 0; i < signsArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    signsArray[i] = ReplacementChar;
                }
            }
        }

        private static void ChangeFileContentSymbolsInBlocks(StreamReader sr)
        {
            char[] buffer;
            int size = 1024 * 1024;
            buffer = new char[size];

            int maxLength = sr.ReadToEnd().Length;
            int length = 0;
            while(length <= maxLength)
            {
                sr.ReadBlock(buffer, 0, size - 1);
                for (int i = 0; i < buffer.Length; i++)
                {
                    if(i%2 == 0)
                    {
                        buffer[i] = ReplacementChar;
                    }
                }

                strContent += new string(buffer);
                length += size - 1;
            }
        }
    }
}
