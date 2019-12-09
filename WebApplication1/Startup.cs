using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidiling.Startup))]
namespace Vidiling
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
