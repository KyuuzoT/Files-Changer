using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace FilesChanger.Components
{
    public class NameChangerComponent
    {
        public int Power { get; set; }
        private List<string> renamingDictionary = new List<string>();

        public void ProccessRenamingFiles(IEnumerable<FileInfo> files)
        {
            foreach (var item in files)
            {
                RenameFile(item);
            }
        }

        private void RenameFile(FileInfo file)
        {
            string newName, newPath;
            FileInfo tmpFile;

            for (int i = 0; i < Power; i++)
            {
                do
                {
                    newPath = CreateNewFileInformation(file, out newName);
                    tmpFile = new FileInfo(newPath);
                } while (tmpFile.Exists);

                FileSystem.RenameFile(file.FullName, newName);
                file = tmpFile;
            }
        }

        private string CreateNewFileInformation(FileInfo file, out string newName)
        {
            newName = GetNewName(file.Extension);
            string oldPath = file.FullName;
            string newPath = oldPath.Replace(file.Name, newName);
            return newPath;
        }

        private string GetNewName(string extension)
        {
            StringBuilder sb = new StringBuilder();
            string foo = Properties.Resources.dict;
            renamingDictionary = foo.Split('\n').ToList();
            Random rnd = new Random();
            
            int lengthOfName = rnd.Next(1, 3);

            for (int i = 0; i < lengthOfName; i++)
            {
                int position = rnd.Next(0, renamingDictionary.Count);

                string delimiter = lengthOfName > 1 && i < lengthOfName ? " " : "";
                sb.Append($"{renamingDictionary[position].Trim(new char[] {' ', '\r'})}{delimiter}");
            }

            sb.Append(extension);

            return sb.ToString();
        }
    }
}
