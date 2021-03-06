﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WalletHelper.Web.Frontend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static string CaptchaPublicKey { get { return System.Configuration.ConfigurationManager.AppSettings["recaptchaPublicKey"]; } }

        public static string CaptchaPrivateKey { get { return System.Configuration.ConfigurationManager.AppSettings["recaptchaPrivateKey"]; } }

        public static string GetResourceString(string resourceStringName)
        {
            var reacher = new WalletHelper.Business.ResourceReacher(Entity.Enums.ResourceTypes.Web);

            return reacher.GetString(resourceStringName);
        }
    }
}
