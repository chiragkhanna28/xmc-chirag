using Sitecore;
using Sitecore.Pipelines;
using System.Web.Mvc;
using System.Web.Routing;

namespace XmCloudSXAStarter.Infrastructure.Pipelines
{
    public class InitializeRoutes
    {
        public void Process(PipelineArgs args)
        {
            if (!Context.IsUnitTesting)
            {
                RouteTable.Routes.MapRoute("SendEmail", "api/email/{action}", new { controller = "Email" });
            }
        }
    }
}