using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FacebookTest.Startup))]
namespace FacebookTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
