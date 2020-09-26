using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZapatosABCMVCProject.Startup))]
namespace ZapatosABCMVCProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
