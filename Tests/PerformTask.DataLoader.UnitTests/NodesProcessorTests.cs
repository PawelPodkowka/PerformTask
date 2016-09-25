using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Moq;
using NUnit.Framework;
using PerformTask.Common.Exceptions;
using PerformTask.Common.Model;

namespace PerformTask.DataLoader.UnitTests
{
    [TestFixture]
    public class NodesProcessorTests
    {
        [Test]
        public void Process_NodeValidationFails_ThrowsValidationException()
        {
            //given
            var graph = new List<XDocument> { new XDocument(), new XDocument() };
            var processor = new NodesProcessorBuilder().ApplySourceReader(graph)
                                                       .ApplyNodeValidationResult(false)
                                                       .Resolve();

            //when & then
            Assert.Throws<ValidationException>(() => processor.Process());
        }

        [Test]
        public void Process_WhenNoDataRead_NoDataAreSentToTheServer()
        {
            //given
            var processorBuilder = new NodesProcessorBuilder().ApplySourceReader(new List<XDocument>());
            var processor = processorBuilder.Resolve();

            //when
            processor.Process();

            //then
            processorBuilder.DataLoader.Verify(x => x.Load(It.IsAny<IEnumerable<Node>>()), Times.Never);
        }

        [Test]
        public void Process_FolderContainsOneNode_NoDataAreSentToTheServer()
        {
            //given
            var processorBuilder = new NodesProcessorBuilder().ApplySourceReader(new List<XDocument> { new XDocument() });
            var processor = processorBuilder.Resolve();

            //when
            processor.Process();

            //then
            processorBuilder.DataLoader.Verify(x => x.Load(It.IsAny<IEnumerable<Node>>()), Times.Never);
        }

        [Test]
        public void Process_GraphValidationFails_ThrowsValidationException()
        {
            //given
            var graph = new List<XDocument> { new XDocument(), new XDocument() };
            var processor = new NodesProcessorBuilder().ApplySourceReader(graph)
                                                       .ApplyNodeValidationResult(true)
                                                       .ApplyGraphValidationResult(false)
                                                       .Resolve();

            //when & then
            Assert.Throws<GraphValidationException>(() => processor.Process());
        }

        [Test]
        public void Process_AllValidationPass_DataAreSentToTheServer()
        {
            //given
            var graph = new List<XDocument> { new XDocument(), new XDocument() };
            var nodes = new List<Node> {new Node() {Id = 1}, new Node() {Id = 2}};
            var processorBuilder = new NodesProcessorBuilder().ApplySourceReader(graph)
                                                              .ApplyNodeValidationResult(true)
                                                              .ApplyGraphValidationResult(true)
                                                              .ApplyCreatedNodes(graph[0], nodes[0])
                                                              .ApplyCreatedNodes(graph[1], nodes[1]);
            var processor = processorBuilder.Resolve();

            //when
            processor.Process();
            
            //then
            processorBuilder.DataLoader.Verify(x=>x.Load(nodes));
        }


    }
}
