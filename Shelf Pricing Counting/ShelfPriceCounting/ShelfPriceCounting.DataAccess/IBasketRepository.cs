using System.Collections.Generic;
using ShelfPriceCounting.Model;

namespace ShelfPriceCounting.DAL
{
	/// <summary>
	/// Contract for basket repository.
	/// </summary>
	public interface IBasketRepository
    {
	    IList<Basket> GetBaskets();
	    Basket GetBasket(int basketId);
	    void AddBasket(Basket newBasket);
	    void DeleteBasket(int basketId);
	    void DeleteBaskets();
    }
}
