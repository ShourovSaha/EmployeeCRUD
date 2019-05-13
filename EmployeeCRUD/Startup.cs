using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeCRUD.Startup))]
namespace EmployeeCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
