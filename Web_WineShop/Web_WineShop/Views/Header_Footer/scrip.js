// Hàm tính tổng tiền
function calculateTotal() {
    let total = 0;
    // Lấy tất cả các sản phẩm trong giỏ hàng (các sản phẩm có data-price và data-quantity)
    const products = document.querySelectorAll('[data-price][data-quantity]');
    products.forEach(product => {
        const price = parseFloat(product.getAttribute('data-price'));
        const quantity = parseInt(product.getAttribute('data-quantity'));
        if (!isNaN(price) && !isNaN(quantity)) {
            total += price * quantity; // Cộng tổng tiền (giá * số lượng)
        }
    });

    // Cập nhật tổng tiền lên giao diện
    document.getElementById('total-price').innerText = formatCurrency(total);
}

// Hàm xóa sản phẩm khỏi giỏ hàng
function removeProduct(event) {
    const item = event.target.closest('.card-container');
    item.remove();
    calculateTotal(); // Tính lại tổng tiền khi sản phẩm bị xóa
}

// Hàm định dạng tiền tệ (để dễ đọc)
function formatCurrency(amount) {
    return amount.toLocaleString('vi-VN') + " ₫";
}

// Gọi hàm tính tổng tiền khi tải trang
window.onload = calculateTotal;
