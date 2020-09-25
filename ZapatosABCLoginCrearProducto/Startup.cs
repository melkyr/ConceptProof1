using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZapatosABCLoginCrearProducto.Startup))]
namespace ZapatosABCLoginCrearProducto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
