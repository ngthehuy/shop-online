using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.ViewComponents
{
    public class vcArticleSpecial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           DBContext db = new DBContext();
        var data = db.Articles.Where(x => x.Status == true)
                .OrderByDescending(x => x.CreateTime)
                .Take(5).ToList();
            return View(data);
        }
    }
}
