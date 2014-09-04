﻿using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Square9Analytics
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //RouteTable for building endpoints. {parameter} can denote parameters in the URL. Otherwise controller endpoints
            //contain the URI parameters.
            RouteTable.Routes.MapHttpRoute("Users", "analytics/users", new { controller = "Users" });
            RouteTable.Routes.MapHttpRoute("Actions", "analytics/actions", new { controller = "Actions" });
        }
    }
}