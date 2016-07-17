using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Communication.Startup))]

namespace Communication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
