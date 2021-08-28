﻿using System;
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

        private static bool endOfFileFlag = false;

        private static int currentLength = 0;
        private static int maxLength = 0;
        private static char[] buffer;

        internal static void PartialChangeFile(FileInfo file)
        {
            int seekOffset = 0;
            endOfFileFlag = false;
            while (!endOfFileFlag)
            {
                using (var sr = new StreamReader(file.FullName))
                {
                    if (maxLength == 0)
                    {
                        maxLength = sr.ReadToEnd().Length;
                        buffer = new char[1024];
                    }

                    if(buffer.Length <= 0)
                    {
                        return;
                    }

                    buffer = PartialChangeSymbols(sr, buffer.Length);
                    currentLength += buffer.Length;
                }

                using (var bw = new BinaryWriter(File.Open(file.FullName, FileMode.Open)))
                {
                    PartialWriteSymbols(bw, buffer, seekOffset);
                    seekOffset += buffer.Length - 1;
                }

                if (currentLength >= maxLength)
                {
                    endOfFileFlag = true;
                    maxLength = 0;
                    currentLength = 0;
                    buffer = Array.Empty<char>();
                }
            }
        }

        private static char[] PartialChangeSymbols(StreamReader sr, int size)
        {
            char[] buffer = new char[size];

            sr.ReadBlock(buffer, 0, buffer.Length - 1);
            for (int i = 0; i < buffer.Length; i++)
            {
                if(i%2 == 0)
                {
                    buffer[i] = PartialReplacementChar;
                }
            }

            return buffer;
        }

        private static void PartialWriteSymbols(BinaryWriter bw, char[] buffer, int seekOffset)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(new string(buffer));
            bw.Seek(seekOffset, SeekOrigin.Current);
            bw.Write(bytes);
        }
    }
}
