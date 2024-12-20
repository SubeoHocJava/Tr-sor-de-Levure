document.addEventListener("DOMContentLoaded", function () {
    // Load header
    fetch("../Header_Footer/head_2.html")
        .then(response => response.text())
        .then(data => {
            // Chèn HTML vào phần tử header
            document.getElementById("header").innerHTML = data;

            // Sau khi HTML được tải và chèn, gọi hàm JavaScript cần thiết
            calculateTotal();
        });

    // Load footer
    fetch("../Header_Footer/footer.html")
        .then(response => response.text())
        .then(data => document.getElementById("footer").innerHTML = data);
});
