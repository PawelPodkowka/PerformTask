using System;
using System.IO;
using System.Xml.Linq;
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

        public void Read(Action<XDocument> contentAction)
        {
            foreach (var file in Directory.EnumerateFiles(_folderPath, _fileExtensions))
            {
                var xmlDocument = XDocument.Parse(File.ReadAllText(file));
                contentAction(xmlDocument);
            }
        }
    }
}
