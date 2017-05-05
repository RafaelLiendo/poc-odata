using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using PocInheritance.Models;

namespace PocInheritance
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Artigo>("Artigos");
            //builder.EntitySet<Conteudo>("Conteudoes");
            //builder.EntitySet<Usuario>("Usuarios");
            //builder.EntitySet<Imagem>("Imagems");
            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
