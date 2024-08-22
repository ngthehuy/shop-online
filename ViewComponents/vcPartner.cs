using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.ViewComponents
{
    public class vcPartner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           DBContext db = new DBContext();
         var data = db.Pictures.Where(x => x.PictureCategoryId == 2 && x.Status == true)
                .OrderBy(x => x.Position)
                .ToList();
            return View(data);
        }
    }
}
