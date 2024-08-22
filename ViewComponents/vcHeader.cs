using Microsoft.AspNetCore.Mvc;

namespace ShopOnline.ViewComponents
{
    public class vcHeader : ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
