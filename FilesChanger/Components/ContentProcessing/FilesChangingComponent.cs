using System;
using System.IO;
using System.Linq;
using System.Text;

namespace FilesChanger.Components.ContentProcessing
{
    public class FilesChangingComponent
    {
        internal static char ReplacementChar = default;
        private static string strContent = string.Empty;
        private static char[] signsArray = default;

        internal static void ChangeFile(FileInfo file)
        {
            using (var sr = new StreamReader(file.FullName))
            {
                ChangeFileContentSymbols(sr);
            }

            WriteSymbolsToFile(file);
            strContent = "";
        }

        private static void WriteSymbolsToFile(FileInfo file)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(new string(signsArray));
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
            var rnd = new Random();
            int symbolsToChange = 2;

            for (int i = 0; i < signsArray.Length; i++)
            {
                if (i % symbolsToChange == 0)
                {
                    signsArray[i] = ReplacementChar;
                    symbolsToChange = rnd.Next(0, 5);
                }
            }
        }
    }
}
