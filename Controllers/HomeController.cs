using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;
using System.Diagnostics;

namespace ShopOnline.Controllers 
{
    public class HomeController : Controller
    {
        [Route("/", Name = "Home")]
        public IActionResult Index()
        {
           // DBContext db = new DBContext();
            //var data = db.ProductCategories.ToList();
           // var data = db.Accounts.FromSql($"Select * From Account").ToList();
            //var data2 = db.Accounts.FromSql($"Select * From Account Where Usename = 'admin'").ToList();
            //var data3 = db.ProductMainCategories.FromSql($"Exec GetProductMainCategoryList @Status = 1").ToList();

            return View();
        }
    }
}
