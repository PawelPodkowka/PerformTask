using System;

namespace PerformTask.DataLoader.Interfaces
{
    internal interface ISourceReader
    {
        void Read(Action<string> analizeContent);
    }
}
