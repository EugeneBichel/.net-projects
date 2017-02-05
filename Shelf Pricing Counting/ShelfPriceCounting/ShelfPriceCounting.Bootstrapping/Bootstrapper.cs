using Microsoft.Practices.Unity;

namespace ShelfPriceCounting.Bootstrapping
{
	public class Bootstrapper
	{
		/// <summary>
		/// Creates IoC container and registers dependencies.
		/// </summary>
		/// <returns></returns>
		public UnityContainer Bootstrap()
		{
			return IoCContainer.Initialise();
		}
	}
}
