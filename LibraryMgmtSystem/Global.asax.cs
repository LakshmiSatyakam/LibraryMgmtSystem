using LibraryMgmtSystem.App_Start;
using System.Web.Http;

namespace LibraryMgmtSystem
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Configure AutoFac  
            AutoFacConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}
