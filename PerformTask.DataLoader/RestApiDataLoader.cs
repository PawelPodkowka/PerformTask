using System.Collections.Generic;
using PerformTask.Common.Model;
using PerformTask.DataLoader.Interfaces;
using RestSharp;

namespace PerformTask.DataLoader
{
    public class RestApiDataLoader : IDataLoader
    {
        private readonly string _apiEndPiont;
        private const string _resourceName = "nodes";

        public RestApiDataLoader(string apiEndPiont)
        {
            _apiEndPiont = apiEndPiont;
        }

        public void Load(IEnumerable<Node> graph)
        {
            var client = new RestClient(_apiEndPiont);
            var request = new RestRequest(_resourceName, Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddBody(new Node() { Id = 5, Label = "ala ma kota"});
            var result = client.Execute(request);
        }
    }
}
