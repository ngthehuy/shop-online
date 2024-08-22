using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.Controllers
{
    public class ArticleController : Controller
    {
        [Route("/tin-tuc", Name = "ArticleList")]
        public IActionResult Index()
        {
            
            DBContext db = new DBContext();
            var query = from a in db.Articles
                        where a.Status == true
                        orderby Guid.NewGuid()
                        select a;
            var data = query.Take(10).ToList();
            return View(data);
        }

        [Route("/chi-tiet-tin-tuc/{id}/{title}.html", Name = "ArticleDetail")]
        public IActionResult Detail(int id,string title)
        {
            DBContext db = new DBContext();
            var query = db.Articles.FromSql($"Select Top 1 * From Article Where ArticleID = {id}").FirstOrDefault();

            return View(query);
        }
    }
}
