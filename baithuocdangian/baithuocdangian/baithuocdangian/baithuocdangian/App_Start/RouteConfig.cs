using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace baithuocdangian
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("thuocdangian", "suc-khoe-tre-em/{tag}/{*catchall}", new { controller = "Home", action = "Category", tag = UrlParameter.Optional }, new { controller = "^H.*", action = "^vSuckhoetreem$" });
            //routes.MapRoute("thuocdangian", "suc-khoe-phu-nu/{*catchall}", new { controller = "Home", action = "Category", tag = UrlParameter.Optional }, new { controller = "^H.*", action = "^Suckhoephunu$" });
            //routes.MapRoute("thuocdangian", "hoc-vien-onsoft/{*catchall}", new { controller = "Home", action = "vThanhtich", tag = UrlParameter.Optional }, new { controller = "^H.*", action = "^vSuckhoe$" });
            //routes.MapRoute("thuocdangian", "video-huong-dan-lap-trinh/{*catchall}", new { controller = "Home", action = "vVideoIndex", tag = UrlParameter.Optional }, new { controller = "^H.*", action = "^vVideoIndex$" });
            //routes.MapRoute("thuocdangian", "video-hoc-lap-trinh/{tag}/{*catchall}", new { controller = "Home", action = "vVideoChitiet", tag = UrlParameter.Optional }, new { controller = "^H.*", action = "^vVideoChitiet$" });
            //routes.MapRoute("page", "gioi-thieu/{tag}/{*catchall}", new { controller = "Home", action = "vPageIndex", tag = UrlParameter.Optional }, new { controller = "^H.*", action = "^vPageIndex$" });
            //routes.MapRoute("Chitietkhoahoc", "hoc-lap-trinh/{tag}/{*catchall}", new { controller = "Khoahoc", action = "vChitietkhoahoc", tag = UrlParameter.Optional }, new { controller = "^K.*", action = "^vChitietkhoahoc$" });
            //routes.MapRoute("tailieu", "kho-tai-lieu/{*catchall}", new { controller = "NewsDefault", action = "NewsGroup", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^NewsGroup$" });
            //routes.MapRoute("tintuc", "tai-lieu/{tag}/{*catchall}", new { controller = "NewsDefault", action = "NewsIndex", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^NewsIndex$" });
            //routes.MapRoute("chitiettintuc", "tai-lieu-lap-trinh/{tag}/{*catchall}", new { controller = "NewsDefault", action = "NewsDetail", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^NewsDetail$" });
            //routes.MapRoute("completed", "dao-tao-lap-trinh/onsoft/{*catchall}", new { controller = "Khoahoc", action = "Completed", tag = UrlParameter.Optional }, new { controller = "^K.*", action = "^Completed$" });
            //routes.MapRoute("lienhe", "onsoft/lien-he/{*catchall}", new { controller = "Home", action = "vPageContact", tag = UrlParameter.Optional }, new { controller = "^H.*", action = "^vPageContact$" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
