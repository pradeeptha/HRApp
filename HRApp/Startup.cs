using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRApp.Startup))]
namespace HRApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
