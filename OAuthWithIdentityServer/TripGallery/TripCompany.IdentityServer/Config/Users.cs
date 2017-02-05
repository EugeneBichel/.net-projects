using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;

namespace TripCompany.IdentityServer.Config
{
	public static class Users
	{
		public static List<InMemoryUser> Get()
		{
			return new List<InMemoryUser>
			{
				new InMemoryUser
				{
					Username = "Kevin",
					Password="secret",
					Subject="5e4f1417-0dc6-4ef0-9f18-02da43f027a5"
				},
				new InMemoryUser
				{
					Username = "Sven",
					Password="secret",
					Subject="10409342-df13-4563-b45c-9a0fcaa77925"
				}
			};
		}
	}
}