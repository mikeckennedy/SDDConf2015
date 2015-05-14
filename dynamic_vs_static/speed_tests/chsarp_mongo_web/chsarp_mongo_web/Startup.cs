using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chsarp_mongo_web.Startup))]
namespace chsarp_mongo_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
