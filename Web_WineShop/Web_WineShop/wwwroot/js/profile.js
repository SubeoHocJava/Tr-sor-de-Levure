$(document).ready(function () {
    //collapse
    $('.collapse-content').hide();
    $('.collapse-btn').click(function () {
        var index = $(this).index('.collapse-btn');
        $('.collapse-content').eq(index).slideToggle();
    });
    //revieved-order
    $('.recieved_order-btn').on('click', function () {
        $(this).prev('.buy_again-btn').removeClass('disabled-btn');
        $(this).addClass('disabled-btn');
    });

    // Hiển thị phần "Account Overview" mặc định khi trang được tải
    $('#account-overview').removeClass('d-none');

    // Chọn menu
    $('ul.new-list li').on('click', function () {
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

    function updateProgressBar(progressPercentage) {
        $('#progressFill').css('width', progressPercentage + '%'); // Set progress width
    }

    updateProgressBar(50); 

});
