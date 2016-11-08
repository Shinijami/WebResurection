using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebResurection.Startup))]
namespace WebResurection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
