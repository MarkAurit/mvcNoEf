using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc4NoEF.Startup))]
namespace Mvc4NoEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
