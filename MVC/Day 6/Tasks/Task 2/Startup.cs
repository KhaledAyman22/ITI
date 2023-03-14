using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task_2.Startup))]
namespace Task_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
