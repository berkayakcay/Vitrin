﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShowCase
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "UsersRoute",
                url: "Users/{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ItemsRoute",
                url: "Items/{controller}/{action}/{id}",
                defaults: new { controller = "Item", action = "Index", id = UrlParameter.Optional }
            );  

            routes.MapRoute(
                name: "ProductRoute",
                url: "Product/{id}",
                defaults: new {controller = "Product", action = "Index", id = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "CategoryRoute",
                url: "Category/{id}",
                defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
