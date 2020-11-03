using ProductService.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using System.Web.Http;

namespace ProductService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel()
            );
            // Web API routes
            //    config.MapHttpAttributeRoutes();

            //    config.Routes.MapHttpRoute(
            //        name: "DefaultApi",
            //        routeTemplate: "api/{controller}/{id}",
            //        defaults: new { id = RouteParameter.Optional }
            //    );
        }
    }
}
