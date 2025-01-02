$(function () {
    // Khi nhấp vào các bộ lọc
    $(".filter-option").on("click", function () {
        const filterType = $(this).data("filter-type");
        const filterValue = $(this).data("value");

        const filters = {
            brand: null,
            abv: null,
            size: null,
        };
        filters[filterType] = filterValue;
        $.ajax({
            url: "/Whisky/FilterProducts",
            type: "GET",
            data: filters,
            success: function (response) {
                console.log("Filtered Products JSON:", response.data);
                updateProductList(response.data);

            },
            error: function (err) {
                console.error("Error while filtering products:", err);
                alert("Có lỗi xảy ra khi lọc sản phẩm. Vui lòng thử lại.");
            }
        });
    });

    // Hàm cập nhật danh sách sản phẩm
    function updateProductList(products) {
        const productContainer = $(".row-cols-1");
        productContainer.empty(); // Xóa danh sách sản phẩm cũ


        // Tạo HTML mới từ danh sách sản phẩm
        const productHtml = $.map(products, function (product) {
            return `
    <div class="col">
        <div class="card product-card">
            <img src="${product.imageUrl}" class="card-img-top" alt="${product.name}" />
            <div class="card-body">
                <h5 class="card-title">${product.name}</h5>
                <p class="card-text">Dung tích: ${product.size}</p>
                <p class="card-text">Nồng độ: ${product.abv}%</p>
                <div class="price">
                    <p class="card-text">${product.price} đ</p>
                </div>
                <div class="hover-buttons">
                    <button class="btn btn-buy">Mua</button>
                    <button class="btn btn-view">Thêm</button>
                    <button class="btn btn-wishlist">
                        <i class="fa fa-heart"></i>
                    </button>
                </div>
            </div>
        </div>
    </div>
    `;
        }).join("");

        if (!products || products.length === 0) {
            productContainer.html("<p class='text-center'>Không tìm thấy sản phẩm nào phù hợp.</p>");
            return;
        }
        productContainer.html(productHtml);
    }
});
