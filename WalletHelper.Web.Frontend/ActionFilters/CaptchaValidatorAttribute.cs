using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WalletHelper.Web.Frontend
{
    public class CaptchaValidatorAttribute:ActionFilterAttribute
    {
        private const string CHALLENGE_FIELD_KEY = "recaptcha_challenge_field";
        private const string RESPONSE_FIELD_KEY = "recaptcha_response_field";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var captChallengeValue = filterContext.HttpContext.Request.Form[CHALLENGE_FIELD_KEY];
            var captResponseValue = filterContext.HttpContext.Request.Form[RESPONSE_FIELD_KEY];

            var catpchaValidator = new Recaptcha.RecaptchaValidator
                                        {
                                            PrivateKey = MvcApplication.CaptchaPrivateKey,
                                            RemoteIP = filterContext.HttpContext.Request.UserHostAddress,
                                            Challenge = captChallengeValue,
                                            Response = captResponseValue
                                        };

            var recaptchaResponse = catpchaValidator.Validate();

            filterContext.ActionParameters["validCaptcha"] = recaptchaResponse.IsValid;

            base.OnActionExecuting(filterContext);
        }
    }
}