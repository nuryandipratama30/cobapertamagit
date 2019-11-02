using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(percobaan.Startup))]
namespace percobaan
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
