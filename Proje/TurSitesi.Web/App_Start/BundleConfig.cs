using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TurSitesi.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/site/css")
                .Include("~/Content/Site.css",
                         "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/site/mod")
                .Include("~/Scripts/modernizr-2.8.3.js"));

            bundles.Add(new StyleBundle("~/site/js")
                .Include("~/Scripts/jquery-3.4.1.min.js",
                         "~/Scripts/bootstrap.min.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}