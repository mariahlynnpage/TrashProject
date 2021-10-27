using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrashProject.MVC.Startup))]
namespace TrashProject.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
