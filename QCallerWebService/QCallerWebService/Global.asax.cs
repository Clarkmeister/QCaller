using QCallerWebService.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace QCallerWebService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Startup Code Goes Here
            StartupFunctions.LoadRestaurants();
        }
    }
}
