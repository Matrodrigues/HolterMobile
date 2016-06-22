using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HolterMobile.Startup))]
namespace HolterMobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
