using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Locamer2.Startup))]
namespace Locamer2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
