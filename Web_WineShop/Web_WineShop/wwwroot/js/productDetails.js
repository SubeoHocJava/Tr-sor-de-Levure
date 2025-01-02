document.addEventListener("DOMContentLoaded", function () {
    // Lấy các phần tử của nút và khu vực nội dung
    const btnDescription = document.getElementById("btnDescription");
    const btnDetails = document.getElementById("btnDetails");
    const contentArea = document.getElementById("contentArea");
    const quantityInput = document.getElementById("quantityInput");
    const priceSpan = document.getElementById("priceSpan");
    const productId = document.getElementById("productId").value; // Lấy ID sản phẩm

    // Lấy giá gốc từ trang
    const basePrice = parseFloat(priceSpan.innerText.replace('£', ''));

    // Đảm bảo nút mô tả là mặc định khi trang tải
    btnDescription.classList.add("active");
    // Tải mô tả sản phẩm khi trang tải
    fetchProductDetails('description', productId);

    // Lắng nghe sự kiện khi người dùng nhấn nút mô tả
    btnDescription.addEventListener("click", () => {
        btnDescription.classList.add("active");
        btnDetails.classList.remove("active");
        fetchProductDetails('description', productId); // Tải mô tả
    });

    // Lắng nghe sự kiện khi người dùng nhấn nút chi tiết
    btnDetails.addEventListener("click", () => {
        btnDetails.classList.add("active");
        btnDescription.classList.remove("active");
        fetchProductDetails('details', productId); // Tải chi tiết
    });

    // Hàm để tải thông tin mô tả hoặc chi tiết
    function fetchProductDetails(viewType, productId) {
        // Xóa nội dung cũ trong contentArea
        contentArea.innerHTML = '';

        // Gửi yêu cầu AJAX tới controller
        fetch(`/Product/LoadProductDetails?viewType=${viewType}&productId=${productId}`)
            .then(response => response.json())
            .then(data => {
                if (viewType === 'description') {
                    contentArea.innerHTML = data.descriptionHtml; // Cập nhật mô tả
                } else if (viewType === 'details') {
                    contentArea.innerHTML = data.detailsHtml; // Cập nhật chi tiết
                }
            })
            .catch(error => console.error('Error loading product details:', error));
    }

    // Lắng nghe sự thay đổi của input số lượng
    quantityInput.addEventListener("input", function () {
        // Lấy số lượng từ input
        const quantity = parseInt(quantityInput.value);

        // Kiểm tra nếu số lượng hợp lệ (lớn hơn 0)
        if (quantity > 0) {
            // Tính lại giá mới (giá cơ bản * số lượng)
            const updatedPrice = (basePrice * quantity).toFixed(2);

            // Cập nhật giá hiển thị
            priceSpan.innerText = `£${updatedPrice}`;
        }
    });
});
