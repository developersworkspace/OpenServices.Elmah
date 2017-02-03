using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenService.Elmah.WebApp.Startup))]
namespace OpenService.Elmah.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
