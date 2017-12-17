using System.Web.Mvc;

namespace Ingpal.BusinessStore.WebApp.Areas.SaleManage
{
    public class SaleManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SaleManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SaleManage_default",
                "SaleManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}