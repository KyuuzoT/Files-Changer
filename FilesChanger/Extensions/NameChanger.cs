using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace FilesChanger.Extensions
{
    public class NameChanger
    {
        public int Power { get; set; }

        public void ProccessRenamingFiles(IEnumerable<FileInfo> files)
        {
            foreach (var item in files)
            {
                RenameFile(item);
            }
        }

        private void RenameFile(FileInfo file)
        {
            string extension = file.Extension;
            string newName = $"Something{extension}";
            string oldPath = file.FullName;
            string newPath = oldPath.Replace(file.Name, newName);

            FileSystem.RenameFile(file.FullName, newName);
            file = new FileInfo(newPath);

            //for (int i = 0; i < Power; i++)
            //{
            //    FileSystem.RenameFile(file.FullName, newName);
            //    file.FullName.Replace(file.Name, newName);
            //    file = new FileInfo(newName);
            //}
        }
    }
}
