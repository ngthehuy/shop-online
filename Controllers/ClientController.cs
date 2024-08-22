using Microsoft.AspNetCore.Mvc;

namespace ShopOnline.Controllers
{
    public class ClientController : Controller
    {
        [Route("/dang-nhap", Name = "Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/dang-ky", Name = "Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
