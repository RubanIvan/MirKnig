using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);


            routes.MapRoute(
                name: "Search",
                url: "search/{action}/",
                defaults: new { controller = "Search", action = "Index" }
                );

            routes.MapRoute(
                 name: "Login",
                 url: "account/{action}",
                 defaults: new { controller = "account", action = "Login" }
             );

            routes.MapRoute(
               name: "Book",
               url: "{controller}/{bookid}",
               defaults: new { controller = "Book", action = "Index" }
           );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{genreid}/{page}",
               defaults: new { controller = "Genre", action = "Index", genreid = UrlParameter.Optional, page = UrlParameter.Optional }
           );



        }
    }
}
