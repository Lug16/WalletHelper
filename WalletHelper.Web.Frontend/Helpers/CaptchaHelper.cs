﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
//La libreria recaptcha se puede descargar en https://code.google.com/p/recaptcha/downloads/list?q=label:aspnetlib-Latest

namespace WalletHelper.Web.Frontend.Helpers
{
    public static class CaptchaHelper
    {

        public static MvcHtmlString GenerateCaptcha(this HtmlHelper helper)
        {
            
            var captchaControl = new Recaptcha.RecaptchaControl
                                        {
                                            ID = "recaptcha",
                                            Theme = "clean",
                                            PublicKey = MvcApplication.CaptchaPublicKey,
                                            PrivateKey = MvcApplication.CaptchaPrivateKey,
                                            Language=Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName
                                        };

            var htmlWriter = new HtmlTextWriter(new StringWriter());

            captchaControl.RenderControl(htmlWriter);

            return new MvcHtmlString(htmlWriter.InnerWriter.ToString());
        }
    }
}