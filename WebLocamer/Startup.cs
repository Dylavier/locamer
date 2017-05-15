using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLocamer.Startup))]
namespace WebLocamer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
