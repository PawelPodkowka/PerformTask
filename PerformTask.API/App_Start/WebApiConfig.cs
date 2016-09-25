using System.Web.Http;
using DryIoc;
using DryIoc.WebApi;
using PerformTask.API.DAL;
using PerformTask.API.Repositories;
using PerformTask.Common.Services;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using PerformTask.Common.Model;
using PerformTask.API.Comparers;

namespace PerformTask.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new Container().WithWebApi(config);
            InstallDependencies(container);

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void InstallDependencies(IContainer container)
        {
            container.Register<IGraphPathFinder, GraphPathFinder>();
            container.Register<NodesContext>(setup: Setup.With(allowDisposableTransient: true, trackDisposableTransient: true));
            container.Register<INodesRepository, NodesRepository>();
            container.Register<IEqualityComparer<Connection>, BidirectionalConnectionComparer>();
        }
    }
}
