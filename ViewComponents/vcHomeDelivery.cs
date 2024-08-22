using Microsoft.AspNetCore.Mvc;

namespace ShopOnline.ViewComponents
{
    public class vcHomeDelivery : ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
