using Microsoft.AspNetCore.Mvc;
using ShopOnline.Helpers;

namespace ShopOnline.Controllers
{
    public class CartController : Controller
    {
        private readonly SessionUtility _sessionUtility;

        public CartController(SessionUtility sessionUtility)
        {
            _sessionUtility = sessionUtility;
        }

        [Route("/gio-hang", Name = "ShoppingCart")]
        public IActionResult ShoppingCart()
        {
            var cart = _sessionUtility.Cart;
            return View(cart);
        }

        [Route("/thanh-toan", Name = "Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Route("/add-to-cart", Name = "AddToCart")]
        public IActionResult AddToCart(int productId, string productName, double productPrice, double oldPrice, int quantity, string avatar)
        {
            var cart = _sessionUtility.Cart;
            cart.AddItem(productId, productName, productPrice, oldPrice, quantity, avatar);
            _sessionUtility.Cart = cart;

            return RedirectToRoute("ShoppingCart");
        }

        [HttpPost]
        [Route("/remove-from-cart", Name = "RemoveFromCart")]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = _sessionUtility.Cart;
            cart.RemoveItem(productId);
            _sessionUtility.Cart = cart;

            return Ok();
        }

        [HttpPost]
        [Route("/update-cart-item", Name = "UpdateCartItem")]
        public IActionResult UpdateCartItem(int productId, int quantity)
        {
            var cart = _sessionUtility.Cart;

            var cartItem = cart.CartDetails.FirstOrDefault(item => item.ProductID == productId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
            }

            _sessionUtility.Cart = cart;

            return Ok();
        }

        [HttpPost]
        [Route("/save-cart-info", Name = "SaveCartInfo")]
        public IActionResult SaveCartInfo(Cart cartInfo)
        {
            var cart = _sessionUtility.Cart;

            cart.FullName = cartInfo.FullName;
            cart.Email = cartInfo.Email;
            cart.Mobile = cartInfo.Mobile;
            cart.Mobile2 = cartInfo.Mobile2;
            cart.Address = cartInfo.Address;

            _sessionUtility.Cart = cart;

            return Ok();
        }

    }
}
