using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PerformTask.Common.Exceptions;
using PerformTask.Common.Model;
using PerformTask.Common.Validators;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    public class NodesProcessor : INodesProcessor
    {
        private const int MIN_NUMBER_OF_NODES = 2;
        private readonly ISourceReader _sourceReader;
        private readonly IDataLoader _loader;
        private readonly INodeCreator _nodeCreator;
        private readonly IValidator<XDocument> _nodeValidator;
        private readonly IValidator<IEnumerable<Node>> _graphValidator;

        public NodesProcessor(ISourceReader sourceReader, IDataLoader loader, INodeCreator nodeCreator, IValidator<XDocument> nodeValidator, IValidator<IEnumerable<Node>> graphValidator)
        {
            _sourceReader = sourceReader;
            _loader = loader;
            _nodeCreator = nodeCreator;
            _nodeValidator = nodeValidator;
            _graphValidator = graphValidator;
        }

        public void Process()
        {
            var nodes = LoadNodes();
            if (nodes == null) return;

            ValidateGraphStructure(nodes);
            _loader.Load(nodes);
        }
        
        private IEnumerable<Node> LoadNodes()
        {
            var documents = _sourceReader.ReadNodes();
            if (documents.Count() < MIN_NUMBER_OF_NODES) return null;

            ValidatieNodeContents(documents);
            return documents.Select(x => _nodeCreator.Create(x));
        }

        private void ValidatieNodeContents(IEnumerable<XDocument> documents)
        {
            if (documents.Any(document => !_nodeValidator.Validate(document)))
            {
                throw new ValidationException("Node is incorrect");
            }
        }

        private void ValidateGraphStructure(IEnumerable<Node> nodes)
        {
            if (!_graphValidator.Validate(nodes))
                throw new GraphValidationException("Graph has incorrect structure");
        }
    }  
}
