using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcodev.Startup))]
namespace mvcodev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
