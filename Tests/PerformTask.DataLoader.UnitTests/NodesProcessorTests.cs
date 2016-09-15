using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Moq;
using NUnit.Framework;
using PerformTask.Common.Exceptions;
using PerformTask.Common.Model;
using PerformTask.Common.Validators;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader.UnitTests
{
    [TestFixture]
    public class NodesProcessorTests
    {
        [Test]
        public void Process_NodeValidationFails_ThrowsValidationException()
        {
            //given
            var sourceReader = new Mock<ISourceReader>();
            sourceReader.Setup(x => x.ReadNodes())
                        .Returns(new List<XDocument> { new XDocument(), new XDocument() });

            var nodeValidator = new Mock<IValidator<XDocument>>();
            nodeValidator.Setup(x => x.Validate(It.IsAny<XDocument>()))
                         .Returns(false);

            var processor = new NodesProcessor(sourceReader.Object, null, null, nodeValidator.Object, null);

            //when
            Assert.Throws<ValidationException>(() => processor.Process());
        }

        [Test]
        public void Process_WhenNoDataRead_NoDataAreSentToTheServer()
        {
            //given
            var sourceReader = new Mock<ISourceReader>();
            sourceReader.Setup(x => x.ReadNodes())
                        .Returns(new List<XDocument>());

            var dataLoader = new Mock<IDataLoader>();
            var processor = new NodesProcessor(sourceReader.Object, dataLoader.Object, null, null, null);

            //when
            processor.Process();

            //then
            dataLoader.Verify(x=>x.Load(It.IsAny<IEnumerable<Node>>()), Times.Never);
        }

        [Test]
        public void Process_FolderContainsOneNode_NoDataAreSentToTheServer()
        {
        }

        [Test]
        public void Process_GraphValidationFails_ThrowsValidationException()
        {
        }

        
    }
}
