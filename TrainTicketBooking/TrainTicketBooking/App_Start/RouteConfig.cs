using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrainTicketBooking
{
    /// <summary>
    /// Creates a route configuration
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Defines the routes the application uses. 
        /// </summary>
        /// <param name="routes">The name of collectino of routes to be used</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
