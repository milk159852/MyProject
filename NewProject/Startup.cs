using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewProject.Startup))]
namespace NewProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
