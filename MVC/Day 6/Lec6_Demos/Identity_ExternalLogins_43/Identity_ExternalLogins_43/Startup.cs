using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Identity_ExternalLogins_43.Startup))]
namespace Identity_ExternalLogins_43
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
