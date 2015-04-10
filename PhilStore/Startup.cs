using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhilStore.Startup))]
namespace PhilStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
