using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskEr.Startup))]
namespace TaskEr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
