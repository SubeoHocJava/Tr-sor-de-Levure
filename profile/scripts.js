$(document).ready(function () {
    // Hiển

    // Ẩn tất cả các phần tử collapse-content khi trang tải
    $('.collapse-content').hide();

    // Khi nhấp vào nút collapse
    $('.collapse-btn').click(function () {
        var index = $(this).index('.collapse-btn');
        $('.collapse-content').eq(index).slideToggle();
    });
    // Hiển thị phần "Account Overview" mặc định khi trang được tải
    $('#account-overview').removeClass('d-none');

    // Thêm sự kiện khi người dùng click vào các mục menu
    $('ul.new-list li').on('click', function () {
        // Ẩn tất cả các phần chi tiết
        $('.detail-form').addClass('d-none');

        // Lấy mục tiêu (section) của phần tử được click
        var target = $(this).data('target');

        // Hiển thị phần mục tiêu
        $('#' + target).removeClass('d-none');

        // Loại bỏ lớp 'active' khỏi tất cả các mục trong danh sách
        $('ul.new-list li').removeClass('active');

        // Thêm lớp 'active' vào mục đã được click
        $(this).addClass('active');
    });

    // Tùy chọn: Bạn có thể làm nổi bật phần đang hoạt động khi trang tải, dựa trên phần hiện tại
    var currentPage = window.location.hash.replace('#', '') || 'account-overview'; // Mặc định là 'account-overview'
    $('#' + currentPage).removeClass('d-none');
    $('ul.new-list li[data-target="' + currentPage + '"]').addClass('active');
});

// Xét rank user (tạm)
function updateProgressBar(progressPercentage) {
    const progressFill = document.getElementById('progressFill');
    progressFill.style.width = progressPercentage + '%'; // Set progress width
}

// Example of updating the progress to 50% (You can dynamically change this value)
updateProgressBar(50); // You can change 50 to any value based on the user's progress.


