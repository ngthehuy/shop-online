using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.Controllers
{
    public class ProductController : Controller
    {
        [Route("/san-pham", Name = "ProductList")]
        [Route("/san-pham/page/{page}", Name = "ProductListPage")]
        [Route("/san-pham/mid/{mID}/{title}/{page?}", Name = "ProductListByMainCat")]
        [Route("/san-pham/mid/{mID}/cid/{cId}/{title}/{page?}", Name = "ProductListBySubCat")]
        public IActionResult Index(int mID,int cID,string title, int? page)
        {
            DBContext db = new DBContext();
            var query = db.Products.Where(x => x.Status == true)
                .Include(x => x.ProductCategory)
                .OrderByDescending(x => x.CreateTime)
                .AsQueryable();

            ViewBag.CatTitle = "Sản phẩm";
            string pagingURL = string.Empty;
            pagingURL = $"/san-pham/page/{{0}}";
            if (cID > 0) 
            {
                
                query = query.Where(x => x.ProductCategoryId == cID);
                var catItem = db.ProductCategories.FirstOrDefault(x => x.ProductCategoryId == cID);
                if(catItem != null)
                {
                    ViewBag.CatTitle = catItem.Title;
                }
                pagingURL = $"/san-pham/mid/{mID}/cid/{cID}/{title}/{{0}}";
            }
            else if(mID > 0) 
            {
                
                query = query.Where(x => x.ProductCategory.ProductMainCategoryId == mID);
                var catItem = db.ProductMainCategories.FirstOrDefault(x => x.ProductMainCategoryId == mID);
                if (catItem != null)
                {
                    ViewBag.CatTitle = catItem.Title;

                }
                pagingURL = $"/san-pham/mid/{mID}/{title}/{{0}}";
            }
            // xử lý paging//

            if(page == null || page <= 1)
            {
                page = 1;
            }
            int pageSize = 12;
            int skip = (page.Value - 1) * pageSize;
            

            ViewBag.pagingTotal = query.Count();
            ViewBag.pagingSize = pageSize;
            ViewBag.pagingPage = page;
            ViewBag.pagdingURL = pagingURL;

            var data = query.Skip(skip).Take(pageSize).ToList();
            return View(data);
        }

        [Route("/xem-san-pham/{id}/{title}", Name = "ProductDetail")]
        public IActionResult Detail(int id,string title)
        {
            DBContext db = new DBContext();
            var data = db.Products
                .FirstOrDefault(x => x.Status == true && x.ProductId == id);


            return View(data);
        }
    }
}
