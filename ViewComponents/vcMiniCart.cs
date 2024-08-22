using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Helpers;
using ShopOnline.Models;

namespace ShopOnline.ViewComponents
{
    public class vcMiniCart : ViewComponent
    {
        private readonly SessionUtility _sessionUtility;

        public vcMiniCart(SessionUtility sessionUtility)
        {
            _sessionUtility = sessionUtility;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _sessionUtility.Cart;
            return View(cart);
        }
    }
}
