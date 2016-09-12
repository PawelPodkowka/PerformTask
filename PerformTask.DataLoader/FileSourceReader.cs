using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    internal class FileSourceReader : ISourceReader
    {
        private readonly string _folderPath;
        private const string _fileExtensions = "*.xml";

        public FileSourceReader(string folderPath)
        {
            _folderPath = folderPath;
        }

        public void Read(Action<string> analizeContent)
        {
            foreach (var file in Directory.EnumerateFiles(_folderPath, _fileExtensions))
            {
                analizeContent(File.ReadAllText(file));
            }
        }
    }
}
