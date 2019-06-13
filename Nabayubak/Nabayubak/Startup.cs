using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nabayubak.Startup))]
namespace Nabayubak
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
