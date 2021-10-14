using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VacationHire.Startup))]
namespace VacationHire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
