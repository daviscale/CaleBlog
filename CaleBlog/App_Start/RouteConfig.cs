﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaleBlog.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Post", action = "Home" }
            );

            routes.MapRoute(
                name: null,
                url: "Post/List",
                defaults: new { controller = "Post", action = "List" }
            );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new
                {
                    Controller = "Post",
                    action = "List"
                }
            );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Post", action = "List", id = UrlParameter.Optional }
            );


        }
    }
}
