using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZenithWebSite.Startup))]
namespace ZenithWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
