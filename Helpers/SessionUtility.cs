using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ShopOnline.Helpers
{
    public class SessionUtility
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionUtility(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart Cart
        {
            get
            {
                //Lazy load: nếu chưa có đơn hàng, thì tự động tạo đơn hàng mới
                if (_httpContextAccessor.HttpContext.Session.GetObject<Cart>("Cart") == null)
                {
                    _httpContextAccessor.HttpContext.Session.SetObject("Cart", new Cart());
                }

                return _httpContextAccessor.HttpContext.Session.GetObject<Cart>("Cart");
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject("Cart", value);
            }
        }
    }
}
