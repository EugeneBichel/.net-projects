using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ShelfPriceCounting.Model;

namespace ShelfPriceCounting.DAL.JSON
{
	/// <summary>
	/// Repository for baskets from JSON persistent storage.
	/// </summary>
	public class JsonBasketRepository : IBasketRepository
	{
		/// <summary>
		/// Baskets JSON storage.
		/// </summary>
		public readonly string BasketsFileName = "Baskets.json";
		/// <summary>
		/// Key in app.config file.
		/// </summary>
		public readonly string BasketsFileNameKey = "BasketsFileName";

		public JsonBasketRepository()
		{
			BasketsFileName = ConfigurationManager.AppSettings[BasketsFileNameKey] ?? BasketsFileName;
		}

	/// <summary>
		/// Returns basket collection.
		/// </summary>
		public IList<Basket> GetBaskets()
		{
			var baskets = new List<Basket>();

			using (var fileStream = File.Open(BasketsFileName, FileMode.OpenOrCreate))
			{
				using (var streamReader = new StreamReader(fileStream))
				{
					var serializer = new JsonSerializer();
					var actualBaskets = (IList<Basket>)serializer.Deserialize(streamReader, typeof(IList<Basket>));

					if (actualBaskets != null && actualBaskets.Any())
					{
						baskets.AddRange(actualBaskets);
					}
				}
			}

			return baskets;
		}

		/// <summary>
		/// Returns a basket by Id
		/// </summary>
		/// <param name="basketId">basket id</param>
		public Basket GetBasket(int basketId)
		{
			return GetBaskets().FirstOrDefault(basket => basket.Id == basketId);
		}

		public void AddBasket(Basket newBasket)
		{
			throw new NotImplementedException();
		}

		public void DeleteBasket(int basketId)
		{
			throw new NotImplementedException();
		}

		public void DeleteBaskets()
		{
			throw new NotImplementedException();
		}
	}
}
