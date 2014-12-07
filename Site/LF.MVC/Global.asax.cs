using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using LF.DBManager;

namespace LF.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Directory.SetCurrentDirectory(Server.MapPath("~"));

            ClientDataTypeModelValidatorProvider.ResourceClassKey = "Errors";
            DefaultModelBinder.ResourceClassKey = "Errors";

            NHManager.Start();
        }

        protected void Application_BeginRequest()
        {
            if (!isAsset)
                NHManager.Open();
        }

        protected void Application_Error()
        {
            error();
        }


        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (isAsset) return;

            NHManager.Close();

            if (Request["Error"] == "Force")
                throw new Exception("Forced error.");
        }



        private static void error()
        {
            try
            {
                NHManager.Error();
            }
            catch (Exception e)
            {
                if (e.Message != "Restart the Application.")
                    throw;
            }
        }


        // ReSharper disable InconsistentNaming
        protected void Application_End()
        // ReSharper restore InconsistentNaming
        {
            NHManager.End();
        }



        private static Uri url { get { return HttpContext.Current.Request.Url; } }
        private static Boolean isAsset { get { return url.AbsolutePath.ToLowerInvariant().StartsWith("/assets/"); } }





    }
}