using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Moq;
using PerformTask.Common.Model;
using PerformTask.Common.Validators;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader.UnitTests
{
    internal class NodesProcessorBuilder
    {
        public Mock<ISourceReader> SourceReader { get; }
        public Mock<IValidator<XDocument>> NodeValidator { get; }
        public Mock<IDataLoader> DataLoader { get; }
        public Mock<INodeCreator> NodeCreator { get; }
        public Mock<IValidator<IEnumerable<Node>>> GraphValidator { get; }

        public NodesProcessorBuilder()
        {
            DataLoader = new Mock<IDataLoader>();
            NodeCreator = new Mock<INodeCreator>();
            SourceReader = new Mock<ISourceReader>();
            NodeValidator = new Mock<IValidator<XDocument>>();
            GraphValidator = new Mock<IValidator<IEnumerable<Node>>>();
        }

        public NodesProcessorBuilder ApplySourceReader(List<XDocument> nodes)
        {
            SourceReader.Setup(x => x.ReadNodes())
                        .Returns(nodes);
            return this;
        }

        public NodesProcessorBuilder ApplyNodeValidationResult(bool result)
        {
            NodeValidator.Setup(x => x.Validate(It.IsAny<XDocument>()))
                         .Returns(result);

            return this;
        }

        public NodesProcessorBuilder ApplyGraphValidationResult(bool result)
        {
            GraphValidator.Setup(x => x.Validate(It.IsAny<IEnumerable<Node>>()))
                          .Returns(result);

            return this;
        }

        public NodesProcessorBuilder ApplyCreatedNodes(XDocument document, Node node)
        {
            NodeCreator.Setup(x => x.Create(document))
                       .Returns(node);

            return this;
        }

        public NodesProcessor Resolve()
        {
            return new NodesProcessor(SourceReader.Object,
                                      DataLoader.Object,
                                      NodeCreator.Object,
                                      NodeValidator.Object,
                                      GraphValidator.Object);
        }
    }
}
