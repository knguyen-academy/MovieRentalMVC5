using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieRentalMVC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //add custom router for ByReleaseDate action in Movie Controller
            routes.MapRoute(
                "MoviesByReleaseDate",  //Name
                "movies/released/{year}/{month}",   //URL partern
                new {controller = "Movies", action = "ByReleaseDate"},   //default
                new { year = @"\d{4}", month = @"\d{2}" }
                );


            // Default Route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
