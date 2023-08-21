using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeneralTestWebSite.Startup))]
namespace GeneralTestWebSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
