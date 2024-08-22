using Microsoft.AspNetCore.Mvc;

namespace ShopOnline.ViewComponents
{
    public class HomeSpeacialProduct : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
