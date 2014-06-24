using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using WalletHelper.Business;


namespace WalletHelper.Web.Frontend
{
    [AttributeUsageAttribute(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DisplayWithResource:DisplayNameAttribute
    {
        public override string DisplayName
        {
            get
            {
                ResourceReacher reacher = new ResourceReacher(Entity.Enums.ResourceTypes.Web);
                return reacher.GetString(ResourceFieldName);
            }
        }

        public string ResourceFieldName { get; set; }
    }
}