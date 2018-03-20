using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(baithuocdangian.Startup))]
namespace baithuocdangian
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
