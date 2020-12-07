using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ELO
{
    public class FileManager
    {
        public List<File> files { get; private set; }

        public FileManager()
        {
            files = new List<File>();
        }

        public void AddFile(File file)
        {
            files.Add(file);
        }

        public File GetFile(string fileName)
        {
            return files.Find(x => x.FileName == fileName);
        }

        public File GetFile(string filePath, string fileName)
        {
            return files.Find(x => (x.FilePath == filePath) && (x.FileName == fileName));
        }

        public List<File> GetFileList()
        {
            return files;
        }
    }
}
