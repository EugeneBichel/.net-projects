using Microsoft.Practices.Unity;
using ShelfPriceCounting.Business;
using ShelfPriceCounting.DAL;
using ShelfPriceCounting.DAL.JSON;
using ShelfPriceCounting.Rounding;
using ShelfPriceCounting.Rounding.UpToTheNearest;
using ShelfPriceCounting.TaxSettings;
using ShelfPriceCounting.TaxSettings.AppConfig;

namespace ShelfPriceCounting.Bootstrapping
{
	/// <summary>
	/// IoC container.
	/// </summary>
	public static class IoCContainer
	{
		public static UnityContainer Container { get; private set; }

		public static UnityContainer Initialise()
		{
			Container = BuildUnityContainer();

			return Container;
		}

		private static UnityContainer BuildUnityContainer()
		{
			var container = new UnityContainer();

			RegisterTypes(container);

			return container;
		}

		public static void RegisterTypes(UnityContainer container)
		{
			container.RegisterType<IRoundingStrategy, RoundingUpToTheNearestStrategy>();
			container.RegisterType<IBasketRepository, JsonBasketRepository>();
			container.RegisterType<ITaxSettingsProvider, AppConfigTaxSettingsProvider>();
			container.RegisterType<ReceiptService>();
		}
	}
}
