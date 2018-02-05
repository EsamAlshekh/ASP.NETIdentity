using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.NETIdentity.Startup))]
namespace ASP.NETIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
