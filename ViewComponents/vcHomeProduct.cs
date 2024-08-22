using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.ViewComponents
{
    public class vcHomeProduct : ViewComponent
    {
        public IViewComponentResult Invoke(int ? id)
        {
            DBContext db = new DBContext();
            var data = db.ProductMainCategories
                .Include(x => x.ProductCategories.Where(x => x.Status == true))
                .ThenInclude(x => x.Products.Where(x => x.Status == true && x.ProductCategoryId == id).Take(8))
                .Where(x => x.Status == true)
                .OrderBy(x => x.Position)
                .ToList();

            return View(data);
        }
    }
}
