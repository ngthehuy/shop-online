using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.ViewComponents
{
    public class vcProductMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
         DBContext db = new DBContext();
            var data = db.ProductMainCategories
                            // cấp 2 => .Include//
                         .Include(x => x.ProductCategories)
                         //cap 3 trở lên => .ThenInclude//
                        .Where(x => x.Status == true)   
                        .OrderBy(x => x.Position) 
                        .ToList();

            return View(data);
        }
    }
}
