using Microsoft.AspNetCore.Mvc;
using ShopOnline.Models;

namespace ShopOnline.ViewComponents
{
    public class vcHomeCarosel : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            DBContext db = new DBContext();
            var data = db.Pictures.Where(x => x.PictureCategoryId == 1 && x.Status == true)
                         .OrderBy(x => x.Position)
                         .ToList();

            return View(data);
        }
    }
}
