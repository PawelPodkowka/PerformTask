using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    internal class NodesProcessor : INodesProcessor
    {
        private readonly ISourceReader _sourceReader;
        private readonly IDataLoader _loader;
        private readonly INodeCreator _nodeCreator;
        private readonly IEnumerable<IValidator> _validators;

        public NodesProcessor(ISourceReader sourceReader, IDataLoader loader, INodeCreator nodeCreator, IEnumerable<IValidator> validators)
        {
            _sourceReader = sourceReader;
            _loader = loader;
            _nodeCreator = nodeCreator;
            _validators = validators;
        }

        public void Process()
        {
            var nodes = LoadNodes();
            //_sourceReader.Read(document =>
            //{
            //    if (!ValidatieNodeContent(document)) return;

                

            //    _loader.Load(document);
            //});
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
