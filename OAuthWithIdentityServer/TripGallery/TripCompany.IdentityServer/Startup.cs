using IdentityServer3.Core.Configuration;
using Owin;
using TripCompany.IdentityServer.Config;

namespace TripCompany.IdentityServer
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.Map("/identity", idsrvApp =>
			{
				var idServerServiceFactory = new IdentityServerServiceFactory()
				.UseInMemoryClients(Clients.Get())
				.UseInMemoryScopes(Scopes.Get())
				.UseInMemoryUsers(Users.Get());

				var options = new IdentityServerOptions
				{
					Factory = idServerServiceFactory,
					SiteName = "TripCompany Security Token Service",
					IssuerUri = TripGallery.Constants.TripGalleryIssuerUri,
					PublicOrigin = TripGallery.Constants.TripGallerySTSOrigin
				};

				idsrvApp.UseIdentityServer(options);
			});
		}
	}
}