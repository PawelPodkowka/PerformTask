using System.Web.Configuration;
using System.Web.Mvc;

namespace PerformTask.Web.Controllers
{
    public class ConfigurationController : Controller
    {
        private const string GRAPH_API_ADDRESS = "GraphApiAddress";

        // GET: Configuration
        public string Index()
        {
            return WebConfigurationManager.AppSettings[GRAPH_API_ADDRESS];
        }
    }
}