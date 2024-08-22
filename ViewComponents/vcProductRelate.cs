using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.ViewComponents
{
    public class vcProductRelate : ViewComponent
    {
        public IViewComponentResult Invoke(int? catID)
        {
         DBContext db = new DBContext();
            var data = db.Products
                .Where(x =>x.Status ==true && x.ProductCategoryId == catID)
                .OrderBy(x => Guid.NewGuid())
                .Take(10)
                .ToList();
                         
            return View(data);
        }
    }
}
