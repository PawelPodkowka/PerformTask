using System;
using NUnit.Framework;

namespace PerformTask.DataLoader.UnitTests
{
    [TestFixture]
    public class NodesProcessorTests
    {
        [Test]
        public void Process_FileIsEmpty_ThrowsValidationException()
        {
        }

        [Test]
        public void Process_FileDoesNotContainFullNodeData_ThrowsValidationException()
        {
        }

        [Test]
        public void Process_ExistNodeWithRelationToNodeWithoutDefinition_ThrowsValidationException()
        {
        }

        [Test]
        public void Process_ExistsNodeWhichIsNotDefineAsAdjacentNode_ThrowsValidationException()
        {
        }

        [Test]
        public void Process_FolderIsEmpty_NoDataAreSentToTheServer()
        {
        }

        [Test]
        public void Process_FolderContainsOneNode_NoDataAreSentToTheServer()
        {
        }

        
        
    }
}
