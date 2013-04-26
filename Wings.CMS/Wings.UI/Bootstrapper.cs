using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings.UI
{
    public class Bootstrapper
    {
        public static void Bootstrap()
        {
            //RouteConfigurator.RegisterRoutes(RouteTable.Routes);
            //ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.Container));
            WindsorConfigurator.Configure();
            AwesomeConfigurator.Configure();

            Globals.PicturesPath = HttpContext.Current.Server.MapPath("~/pictures");
            new Worker().Start();
        }
    }
}