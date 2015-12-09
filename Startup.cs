using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prog5.Startup))]
namespace prog5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
