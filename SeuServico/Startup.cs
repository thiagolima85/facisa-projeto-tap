using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeuServico.Startup))]
namespace SeuServico
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
