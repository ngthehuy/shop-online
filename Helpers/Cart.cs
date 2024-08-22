namespace ShopOnline.Helpers
{
    public class Cart
    {
        public int CartID { get; set; }

        //Đếm số lượng sp trong giỏ
        public int Count
        {
            get
            {
                return CartDetails.Sum(x => x.Quantity);
            }
        }

        //Tính tổng số tiền chưa giảm
        public double Total
        {
            get
            {
                return CartDetails.Sum(x => (x.Quantity * x.OldPrice));
            }
        }

        //Tính tổng số tiền đã giảm
        public double Amount
        {
            get
            {
                return CartDetails.Sum(x => (x.Quantity * x.Price));
            }
        }

        //Tính tống số tiền được giảm
        public double Bonus
        {
            get
            {
                return Total - Amount;
            }
        }

        //Thông tin khách hàng
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Mobile2 { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool Gender { get; set; } = false;

        // Danh sách mặt hàng đã chọn
        private List<CartDetail> _CartDetails = new List<CartDetail>();
        public List<CartDetail> CartDetails
        {
            get
            {
                return _CartDetails;
            }
        }

        // Thêm một mặt hàng vào giỏ hàng
        public void AddItem(int productId, string productName, double productPrice, double oldPrice, int quantity, string avatar)
        {
            // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng chưa
            var existingItem = CartDetails.FirstOrDefault(x => x.ProductID == productId);

            if (existingItem != null)
            {
                // Nếu sản phẩm đã tồn tại, chỉ cần cập nhật số lượng
                existingItem.Quantity += quantity;
            }
            else
            {
                // Nếu sản phẩm chưa tồn tại, thêm một mặt hàng mới vào giỏ hàng
                CartDetails.Add(new CartDetail
                {
                    ProductID = productId,
                    Quantity = quantity,
                    Price = productPrice,
                    OldPrice = oldPrice,
                    Title = productName,
                    Avatar = avatar
                });
            }
        }

        // Xóa một mặt hàng
        public void RemoveItem(int productId)
        {
            // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng chưa
            var existingItem = CartDetails.FirstOrDefault(x => x.ProductID == productId);

            if (existingItem != null)
            {
                CartDetails.Remove(existingItem);
            }
        }
    }

    //Thông tin mỗi mặt hàng trong giỏ hàng
    public class CartDetail
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public double TotalPrice
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}
