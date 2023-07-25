using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobFinder_websmithAdmin.Startup))]
namespace JobFinder_websmithAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
