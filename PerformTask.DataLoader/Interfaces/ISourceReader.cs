using System;
using System.Xml.Linq;

namespace PerformTask.DataLoader.Interfaces
{
    internal interface ISourceReader
    {
        void Read(Action<XDocument> contentAction);
    }
}
