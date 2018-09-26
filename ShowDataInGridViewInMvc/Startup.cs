using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShowDataInGridViewInMvc.Startup))]
namespace ShowDataInGridViewInMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
