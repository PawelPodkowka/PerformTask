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
    internal class NodesProcessor : INodesProcessor
    {
        private readonly ISourceReader _sourceReader;
        private readonly IDataLoader _loader;
        private readonly INodeCreator _nodeCreator;
        private readonly IEnumerable<IValidator<XDocument>> _validators;
        private readonly IValidator<IEnumerable<Node>> _graphValidator;

        public NodesProcessor(ISourceReader sourceReader, IDataLoader loader, INodeCreator nodeCreator, IEnumerable<IValidator<XDocument>> validators, IValidator<IEnumerable<Node>> graphValidator)
        {
            _sourceReader = sourceReader;
            _loader = loader;
            _nodeCreator = nodeCreator;
            _validators = validators;
            _graphValidator = graphValidator;
        }

        public void Process()
        {
            var nodes = LoadNodes();
            ValidateGraphStructure(nodes);
            _loader.Load(nodes);
        }

        private IEnumerable<Node> LoadNodes()
        {
            var result = new List<Node>();
            _sourceReader.Read(document =>
            {
                ValidatieNodeContent(document);
                result.Add(_nodeCreator.Create(document));
            });
            return result;
        }

        private void ValidatieNodeContent(XDocument document)
        {
            if (_validators.Any(x => !x.Validate(document)))
                ThrowValidationError("Node is incorrect");
        }

        private void ValidateGraphStructure(IEnumerable<Node> nodes)
        {
            if (!_graphValidator.Validate(nodes))
                ThrowValidationError("Graph has incorrect structure");
        }

        private void ThrowValidationError(string validationMessage)
        {
            throw new ValidationException(validationMessage);
        }
    }  
}
