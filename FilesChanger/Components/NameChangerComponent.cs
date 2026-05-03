using Microsoft.VisualBasic.FileIO;
using System.Text;

namespace FilesChanger.Components
{
    public class NameChangerComponent
    {
        public int Power { get; set; }
        private List<string> renamingDictionary = [];
        private static readonly char[] trimChars = [' ', '\r'];

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
            var oldPath = file.FullName;
            var newPath = oldPath.Replace(file.Name, newName);
            return newPath;
        }

        private string GetNewName(string extension)
        {
            var sb = new StringBuilder();
            var renamingDataSource = Properties.Resources.dict;
            renamingDictionary = [.. renamingDataSource.Split('\n')];
            var rnd = new Random();
            
            int lengthOfName = rnd.Next(1, 3);

            for (int i = 0; i < lengthOfName; i++)
            {
                int position = rnd.Next(0, renamingDictionary.Count);

                string delimiter = lengthOfName > 1 && i < lengthOfName ? " " : "";
                sb.Append($"{renamingDictionary[position].Trim(trimChars)}{delimiter}");
            }

            sb = new StringBuilder(sb.ToString().Trim(' '));
            sb.Append(extension);

            return sb.ToString();
        }
    }
}
