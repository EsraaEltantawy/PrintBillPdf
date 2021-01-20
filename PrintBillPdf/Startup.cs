using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrintBillPdf.Startup))]
namespace PrintBillPdf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
