using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hr.Startup))]
namespace hr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
