﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilesChanger
{
    public class FilesPartialChangingHelper
    {
        internal static char PartialReplacementChar = default;
        internal static FileInfo file;
        private static string partialStrContent = default;
        private static bool endOfFileFlag = false;

        private static int bufferSize = 1024 * 1024;
        private static int currentLength = 0;
        private static int maxLength = 0;

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

        internal async static void PartialChangeFile()
        {
            char[] buffer = new char[bufferSize];
            await Task.Run(() =>
            {
                while(!endOfFileFlag)
            {
                using (var sr = new StreamReader(file.FullName))
                {
                    if (maxLength == 0)
                    {
                        maxLength = sr.ReadToEnd().Length;
                    }
                    buffer = PartialChangeSymbols(sr);
                    currentLength += bufferSize - 1;
                }

                using (var bw = new BinaryWriter(File.Open(file.FullName, FileMode.Open)))
                {
                    PartialWriteSymbols(bw, buffer);
                }

                if(currentLength >= maxLength)
                {
                    endOfFileFlag = true;
                    maxLength = 0;
                }
            }
            });
            
            

                //char[] buffer = new char[bufferSize];
                //using (var sr = new StreamReader(file.FullName))
                //{
                //    int length = 0;
                //    int maxLength = sr.ReadToEnd().Length;
                //    using (var bw = new BinaryWriter(File.Open(file.FullName, FileMode.Open)))
                //    {
                //        while (!endOfFileFlag)
                //        {
                //            buffer = PartialChangeSymbols(sr);

                //            PartialWriteSymbols(bw, buffer);

                //            length += bufferSize;
                //            if (length >= maxLength)
                //            {
                //                endOfFileFlag = true;
                //            }
                //        }
                //    }
                //}

                Thread.Sleep(200);
        }

        private static char[] PartialChangeSymbols(StreamReader sr)
        {
            char[] buffer = new char[bufferSize];
            sr.ReadBlockAsync(buffer, 0, bufferSize - 1);
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