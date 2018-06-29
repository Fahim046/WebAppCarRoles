using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppCarRoles.Startup))]
namespace WebAppCarRoles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
