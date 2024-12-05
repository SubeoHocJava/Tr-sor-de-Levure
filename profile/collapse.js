$(document).ready(function() {
    // Ẩn tất cả các phần tử collapse-content khi trang tải
    $('.collapse-content').hide();
    
    // Khi nhấp vào nút collapse
    $('.collapse-btn').click(function() {
        var index = $(this).index('.collapse-btn'); 
        $('.collapse-content').eq(index).slideToggle();
    });
});
