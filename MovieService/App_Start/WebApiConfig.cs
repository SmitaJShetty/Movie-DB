using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.ModelBinding;
using MovieService.ModelBinder;
using com.Entities;

namespace MovieService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
           
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SearchRoute",
                routeTemplate: "api/Movie/Search/{Key}/{Value}"
                );

            config.Routes.MapHttpRoute(
                name: "MovieGet",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller="Movie",  id=RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
             name: "SortRoute",
             routeTemplate: "api/{controller}/{query}",
             defaults: new { controller = "Movie", query = RouteParameter.Optional }
         );
        }
    }
}
