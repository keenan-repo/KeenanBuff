using KeenanBuff.Web.App_Start;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(OwinStartup))]
namespace KeenanBuff.Web.App_Start
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}