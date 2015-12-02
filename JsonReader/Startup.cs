using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JsonReader.Startup))]
namespace JsonReader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
