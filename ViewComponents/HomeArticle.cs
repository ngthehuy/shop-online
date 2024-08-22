using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.ViewComponents
{
    public class HomeArticle : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           DBContext db = new DBContext();
         var data = db.Articles.FromSql($"Select Top 10 * From Article").ToList();
            return View(data);
        }
    }
}
