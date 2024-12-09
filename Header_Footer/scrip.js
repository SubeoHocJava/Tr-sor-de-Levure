 // Hàm tính tổng tiền
 function calculateTotal() {
    let total = 0;
    // Lấy tất cả các sản phẩm trong giỏ hàng (các sản phẩm có data-price và data-quantity)
    const products = document.querySelectorAll('[data-price][data-quantity]');
    products.forEach(product => {
        const price = parseInt(product.getAttribute('data-price')); // Lấy giá sản phẩm
        const quantity = parseInt(product.getAttribute('data-quantity')); // Lấy số lượng sản phẩm
        total += price * quantity; // Cộng tổng tiền (giá * số lượng)
    });

    // Cập nhật tổng tiền lên giao diện
    document.getElementById('total-price').innerText = formatCurrency(total);
}

// Hàm xóa sản phẩm khỏi giỏ hàng
function removeItem(button) {
    button.closest('.card').remove();
    calculateTotal();
}

// Hàm định dạng tiền tệ (để dễ đọc)
function formatCurrency(amount) {
    return amount.toLocaleString() + " ₫";
}

// Gọi hàm tính tổng tiền khi tải trang
window.onload = calculateTotal;