// Xử lý sự kiện tăng (+) số lượng sản phẩm trước khi thêm vào giỏ hàng
function incrementQuantity() {
    var quantityInput = document.getElementById('qtym');
    quantityInput.value = parseInt(quantityInput.value) + 1;
}

// Xử lý sự kiện giảm (-) số lượng sản phẩm trước khi thêm vào giỏ hàng
function decrementQuantity() {
    var quantityInput = document.getElementById('qtym');
    if (parseInt(quantityInput.value) > 1) {
        quantityInput.value = parseInt(quantityInput.value) - 1;
    }
}

// Xử lý sự kiện khi nhấn nút "Xóa sản phẩm"
$('.remove-item-cart').click(function () {
    var productId = $(this).data('id'); // Lấy productId của sản phẩm được chọn
    var url = $(this).data('url'); // Lấy url post sản phẩm
    $.post(url, { productId: productId }, function () {
        // Sau khi xóa thành công, làm mới lại trang để cập nhật giỏ hàng
        window.location.reload();
    });
});

// Xử lý sự kiện khi nút +/- số lượng sản phẩm trong giỏ hàng
$('.reduced_pop, .increase_pop').click(function () {
    var quantity = $(this).siblings('input[type="text"]').val();
    var productId = $(this).siblings('input[type="text"]').data("productid");

    // Kiểm tra xem nút tăng hay giảm số lượng được nhấn
    if ($(this).hasClass('reduced_pop')) {
        if (quantity > 1) {
            quantity--;
        }
    } else {
        quantity++;
    }

    // Gửi yêu cầu cập nhật số lượng sản phẩm
    updateCartItem(productId, quantity);
});

// Hàm gửi yêu cầu cập nhật số lượng sản phẩm
function updateCartItem(productId, quantity) {
    $.post('/update-cart-item', { productId: productId, quantity: quantity }, function () {
        window.location.reload();
    });
}

// Nút tiếp tục mua hàng
$('#continueShoppingBtn').click(function () {
    // Lấy dữ liệu từ form
    var formData = $('#cartInfoForm').serialize();

    // Gửi yêu cầu POST đến server
    $.post('/save-cart-info', formData, function () {
        // Chuyển hướng đến trang ProductList
        window.location.href = '/san-pham';
    });
});

// Nút "Tiến hành thanh toán"
$('#processShoppingBtn').click(function () {
    // Kiểm tra số lượng sản phẩm trong giỏ hàng
    var itemCount = parseInt($('.cart-popup-count').text());
    if (itemCount === 0) {
        alert('Giỏ hàng của bạn đang trống. Vui lòng thêm sản phẩm vào giỏ hàng trước khi thanh toán.');
        return;
    }

    // Kiểm tra thông tin nhập vào
    var fullName = $('#cartInfoForm input[name="FullName"]').val().trim();
    var email = $('#cartInfoForm input[name="Email"]').val().trim();
    var mobile = $('#cartInfoForm input[name="Mobile"]').val().trim();
    var address = $('#cartInfoForm input[name="Address"]').val().trim();

    // Kiểm tra và focus vào ô bị bỏ trống
    if (fullName === '') {
        alert('Vui lòng nhập họ tên.');
        $('#cartInfoForm input[name="FullName"]').focus();
        return;
    }
    else if (email === '') {
        alert('Vui lòng nhập địa chỉ email.');
        $('#cartInfoForm input[name="Email"]').focus();
        return;
    }
    else if (mobile === '') {
        alert('Vui lòng nhập số điện thoại.');
        $('#cartInfoForm input[name="Mobile"]').focus();
        return;
    }
    else if (address === '') {
        alert('Vui lòng nhập địa chỉ.');
        $('#cartInfoForm input[name="Address"]').focus();
        return;
    }

    // Gửi yêu cầu POST đến server
    $.post('/save-cart-info', $('#cartInfoForm').serialize(), function () {
        // Chuyển hướng đến trang Checkout
        window.location.href = '/thanh-toan';
    });
});
