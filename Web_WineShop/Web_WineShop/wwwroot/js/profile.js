$(function () {
    console.log('jQuery is working');
    //collapse
    $('.collapse-content').hide();
    $('.collapse-btn').on('click', function () {
        var index = $(this).index('.collapse-btn');
        $('.collapse-content').eq(index).slideToggle();
    });
    // Hiển thị phần "Account Overview" mặc định khi trang được tải
    $('#account-overview').removeClass('d-none');

    // Chọn menu
    $('ul.new-list li').on('click', function () {
        $('.detail-form').addClass('d-none');

        // Lấy mục tiêu (section) của phần tử được click
        var target = $(this).data('target');
        var href = $(this).data('href');
        if (href)
            $.ajax({
                url: href,
                type: "Get",
                success: function (data) {
                    $("#" + target).html(data);
                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                    console.log("Status: " + status);
                    console.log("Response: " + xhr.responseText);
                }
            })
        // Hiển thị phần mục tiêu
        $('#' + target).removeClass('d-none');

        // Loại bỏ lớp 'active' khỏi tất cả các mục trong danh sách
        $('ul.new-list li').removeClass('active');

        // Thêm lớp 'active' vào mục đã được click
        $(this).addClass('active');
    });
    $('#confirm-password').on('input', function () {
        const newPassword = $('#new-password').val();
        const confirmPassword = $(this).val();
        if (newPassword != confirmPassword) {
            $('#confirm-password-error').text("Passwords don't match.");
            $('#change-password-btn').addClass('disable-btn')
        }
        else {
            $('#confirm-password-error').text('');
            $('#change-password-btn').removeClass('disable-btn')
        }
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
