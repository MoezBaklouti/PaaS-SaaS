using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Solution.Presentation.Startup))]
namespace Solution.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
