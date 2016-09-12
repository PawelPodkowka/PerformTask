using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    internal class NodesProcessor : INodesProcessor
    {
        private readonly ISourceReader _sourceReader;
        private readonly IDataLoader _loader;
        private readonly IEnumerable<IValidator> _validators;

        public NodesProcessor(ISourceReader sourceReader, IDataLoader loader, IEnumerable<IValidator> validators)
        {
            _sourceReader = sourceReader;
            _loader = loader;
            _validators = validators;
        }

        public void Process()
        {
            _sourceReader.Read(content =>
            {
                if (!ValidatieContent(content)) return;

                _loader.Load(content);
            });
        }

        private bool ValidatieContent(string content)
        {
            return _validators.All(x => x.Validate(content));
        }
    }  
}
