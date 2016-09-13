using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StockTicker.Startup))]

namespace StockTicker
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
