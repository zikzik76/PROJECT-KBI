using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Penjaminan.Startup))]
namespace Penjaminan
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
