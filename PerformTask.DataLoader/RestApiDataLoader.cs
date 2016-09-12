using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformTask.DataLoader.Interfaces;
using RestSharp;

namespace PerformTask.DataLoader
{
    internal class RestApiDataLoader : IDataLoader
    {
        private readonly string _apiEndPiont;

        public RestApiDataLoader(string apiEndPiont)
        {
            _apiEndPiont = apiEndPiont;
        }

        public void Load(string content)
        {
            var client = new RestClient(_apiEndPiont);
            var request = new RestRequest("nodes", Method.POST);
            request.RequestFormat = DataFormat.Json;
            //request.AddXmlBody(content);
            request.AddBody(new Node() { Id = 5, Label = "ala ma kota"});
            var result = client.Execute(request);
        }
    }
}
