using Ecommerce_Movie.data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Movie.data.ViewComponents
{

    [ViewComponent]
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            this._shoppingCart = shoppingCart;
        }


        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
