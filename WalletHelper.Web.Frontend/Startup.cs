using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WalletHelper.Web.Frontend.Startup))]
namespace WalletHelper.Web.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
