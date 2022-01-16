using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab4_5_6_7.Startup))]
namespace Lab4_5_6_7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
