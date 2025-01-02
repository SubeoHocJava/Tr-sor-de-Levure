$(document).ready(function () {
    // Hàm tải danh sách các quốc gia
    function loadCountries() {
        $.ajax({
            url: 'https://restcountries.com/v3.1/all',  // URL để lấy dữ liệu quốc gia
            type: 'GET',
            dataType: 'json',
            beforeSend: function () {
                // Thông báo "Đang tải..." khi đang tải quốc gia
                $('#country').html('<option>Loading...</option>');
            },
            success: function (data) {
                // Xóa các lựa chọn cũ
                $('#country').html('<option value="">Choose your country...</option>');

                // Lặp qua dữ liệu và điền vào dropdown
                $.each(data, function (index, country) {
                    // Tên quốc gia trong trường 'name.common' 
                    var countryName = country.name.common;
                    var countryCode = country.cca2; // Mã quốc gia ngắn (ví dụ: "US", "VN")
                    $('#country').append('<option value="' + countryCode + '">' + countryName + '</option>');
                });
            },
            error: function () {
                // Nếu có lỗi xảy ra, hiển thị thông báo lỗi
                $('#country').html('<option>Error</option>');
            }
        });
    }

    // Gọi hàm để tải danh sách quốc gia khi trang web được tải
    loadCountries();
});