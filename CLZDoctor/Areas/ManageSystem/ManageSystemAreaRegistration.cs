using System.Web.Mvc;

namespace CLZDoctor.Areas.ManageSystem
{
    public class ManageSystemAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ManageSystem";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ManageSystem_default",
                "ManageSystem/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
