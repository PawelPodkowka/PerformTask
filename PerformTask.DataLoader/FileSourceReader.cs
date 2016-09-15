using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using PerformTask.Common.Exceptions;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    public class FileSourceReader : ISourceReader
    {
        private readonly string _folderPath;
        private const string _fileExtensions = "*.xml";

        public FileSourceReader(string folderPath)
        {
            _folderPath = folderPath;
        }

        public IEnumerable<XDocument> ReadNodes()
        {
            return Directory.EnumerateFiles(_folderPath, _fileExtensions)
                            .Select(LoadXml);
        }

        private XDocument LoadXml(string file)
        {
            try
            {
                return XDocument.Load(file);
            }
            catch (XmlException exc)
            {
                throw new ValidationException($"File {file} does not contain proper conent.", exc);
            }
        }
    }
}
