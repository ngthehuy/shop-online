using Microsoft.AspNetCore.Mvc;

namespace ShopOnline.ViewComponents
{
    public class vcFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
