using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformTask.DataLoader.Interfaces;
using PerformTask.DataLoader.Properties;

namespace PerformTask.DataLoader
{
    internal class NodeProcessorFactory
    {
        public INodesProcessor Create(string filePath)
        {
            return new NodesProcessor(new FileSourceReader(filePath), 
                                      CreateRestApiLoader(),
                                      new NodeCreator(), 
                                      CreateValidators());
        }

        private IEnumerable<IValidator> CreateValidators()
        {
            return new List<IValidator>
            {
                new EmptyContentValidator(),
                new XmlNodeStructureValidator()
            };
        }

        private IDataLoader CreateRestApiLoader()
        {
            var apiEndPoint = Settings.Default.ApiUriAddress;
            return new RestApiDataLoader(apiEndPoint);
        }
    }
}
