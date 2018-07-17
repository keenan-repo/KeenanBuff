/*using Microsoft.Owin;
using Owin;
using Hangfire;
using System;

[assembly: OwinStartupAttribute(typeof(KeenanBuff.Startup))]
namespace KeenanBuff
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);

            //if you get a weird error about how you're not good enough to login make sure you have Trusted_Connection=True in the connection string
            GlobalConfiguration.Configuration.UseSqlServerStorage("ApplicationDbContext");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}*/
