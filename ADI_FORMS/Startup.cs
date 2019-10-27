using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADI_FORMS.Startup))]
namespace ADI_FORMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
