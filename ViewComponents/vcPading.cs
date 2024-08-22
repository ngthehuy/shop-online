using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models;

namespace ShopOnline.ViewComponents
{
    public class PagingResource
    {
        public string PageFristUrl { get; set; } = string.Empty;
        public string PageLastUrl { get; set; } = string.Empty;
        public string PagePrevUrl { get; set; } = string.Empty;
        public string PageNextUrl { get; set; } = string.Empty;
        public Dictionary<int, string> PageNumbers { get; set; } = new Dictionary<int, string>();
        public int Page { get; set; } = 1;
    }
    public class vcPading : ViewComponent
    {
        
         public IViewComponentResult Invoke(int totals,int pageSize,int page,string url)
        {
            int totalPages = (int)Math.Ceiling((double)totals / pageSize);
            int pageLast = totalPages;
            int pageFirst = 1;
            int pageNext = page+1;
            int pagePrev = page - 1;
            if (page < 1)
            {
                pagePrev = 1;
            }
            if (pageNext > pageLast)
            {
                pageNext = pageLast;
            }

            string pageFirstURL= string.Format(url,pageFirst);
            string pageLastURL = string.Format(url, pageLast);
            string pageNextURL = string.Format(url, pageNext);
            string pagePrevURL = string.Format(url, pagePrev);


            Dictionary<int, string> pageNumbers = new Dictionary<int, string>();

           
            for (int i = pageFirst; i <= pageLast; i++)
            {
                pageNumbers.Add(i, string.Format(url,i));
            }

            PagingResource data = new PagingResource();
            data.PageFristUrl = pageFirstURL;
            data.PageLastUrl = pageLastURL;
            data.PageNextUrl = pageNextURL;
            data.PagePrevUrl = pagePrevURL;
            data.PageNumbers = pageNumbers;
            data.Page = page;
            return View(data);
        }
    }
}
