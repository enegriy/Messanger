using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Messenger.Startup))]
namespace Messenger
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
