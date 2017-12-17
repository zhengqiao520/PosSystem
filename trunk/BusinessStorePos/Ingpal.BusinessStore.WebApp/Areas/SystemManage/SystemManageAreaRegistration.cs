﻿using System.Web.Mvc;

namespace Ingpal.BusinessStore.WebApp.Areas.SystemManage
{
    public class SystemManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SystemManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //context.MapRoute(
            //    "SystemManage_default",
            //    "SystemManage/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
            context.MapRoute(
          this.AreaName + "_Default",
          this.AreaName + "/{controller}/{action}/{id}",
          new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
          new string[] { "Ingpal.BusinessStore.WebApp.Areas." + this.AreaName + ".Controllers" }
        );
        }
    }
}