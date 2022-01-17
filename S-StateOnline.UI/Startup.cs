using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S_StateOnline.UI.Startup))]
namespace S_StateOnline.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
