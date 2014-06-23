using System;
using System.ComponentModel.DataAnnotations;
using WalletHelper.Business;


namespace WalletHelper.Web.Frontend
{
    [AttributeUsageAttribute(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DisplayWithResource : DisplayAttribute
    {
        public override string ToString()
        {
            ResourceReacher reacher = new ResourceReacher(Entity.Enums.ResourceTypes.Web);
            return reacher.GetString("LoginView.UserName");
        }
    }
}