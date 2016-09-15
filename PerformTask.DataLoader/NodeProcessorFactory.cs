using System.Collections.Generic;
using System.Xml.Linq;
using PerformTask.Common.Validators;
using PerformTask.DataLoader.Interfaces;
using PerformTask.DataLoader.Properties;
using PerformTask.DataLoader.Validators;

namespace PerformTask.DataLoader
{
    public class NodeProcessorFactory
    {
        public INodesProcessor Create(string filePath)
        {
            return new NodesProcessor(new FileSourceReader(filePath), 
                                      CreateRestApiLoader(),
                                      new NodeCreator(),
                                      new XmlNodeStructureValidator(),
                                      new GraphValidator());
        }

        private IDataLoader CreateRestApiLoader()
        {
            var apiEndPoint = Settings.Default.ApiUriAddress;
            return new RestApiDataLoader(apiEndPoint);
        }
    }
}
