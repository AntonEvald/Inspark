using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Inspark2.MobileAppService.Startup))]

namespace Inspark2.MobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}