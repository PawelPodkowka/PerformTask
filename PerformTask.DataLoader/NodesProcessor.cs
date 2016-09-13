using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PerformTask.Common.Validators;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    internal class NodesProcessor : INodesProcessor
    {
        private readonly ISourceReader _sourceReader;
        private readonly IDataLoader _loader;
        private readonly INodeCreator _nodeCreator;
        private readonly IEnumerable<IValidator<XDocument>> _validators;

        public NodesProcessor(ISourceReader sourceReader, IDataLoader loader, INodeCreator nodeCreator, IEnumerable<IValidator<XDocument>> validators)
        {
            _sourceReader = sourceReader;
            _loader = loader;
            _nodeCreator = nodeCreator;
            _validators = validators;
        }

        public void Process()
        {
            var nodes = LoadNodes();
            
        }

        private IEnumerable<Node> LoadNodes()
        {
            var result = new List<Node>();
            _sourceReader.Read(document =>
            {
                if (!ValidatieNodeContent(document))
                    throw new ArgumentException("Node is incorrect");
                
                result.Add(_nodeCreator.Create(document));
            });
            return result;
        }

        private bool ValidatieNodeContent(XDocument document)
        {
            return _validators.All(x => x.Validate(document));
        }
    }  
}
