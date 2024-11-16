// Lấy tham chiếu tới tất cả các trường mật khẩu và biểu tượng "mắt"
const passwordFields = document.querySelectorAll('input[type="password"]');
const eyeIcons = document.querySelectorAll('.eye-icon');

// Thêm sự kiện khi người dùng nhấp vào biểu tượng "mắt"
eyeIcons.forEach((eyeIcon, index) => {
    eyeIcon.addEventListener('click', function () {
        // Thay đổi kiểu hiển thị của trường mật khẩu giữa 'password' và 'text'
        const type = passwordFields[index].type === 'password' ? 'text' : 'password';
        passwordFields[index].type = type;

        // Thay đổi biểu tượng "mắt" thành "mắt gạt" khi mật khẩu được hiển thị
        this.classList.toggle('fa-eye-slash');
    });
});

// Khởi tạo jQuery UI Datepicker cho trường ngày sinh
$("#registration-form-dob").datepicker({
    changeMonth: true,  // Cho phép thay đổi tháng
    changeYear: true,   // Cho phép thay đổi năm
    yearRange: "1900:2020", // Giới hạn năm từ 1900 đến 2020
    dateFormat: "mm/dd/yy"  // Định dạng ngày tháng là mm/dd/yy
});

// Fetch dữ liệu các quốc gia từ API Restcountries và điền vào dropdown location
$(document).ready(function () {
    // Lấy danh sách quốc gia từ API
    $.get('https://restcountries.com/v3.1/all', function (data) {
        const locationSelect = $('#location');  // Lấy phần tử dropdown location
        locationSelect.empty(); // Xóa tùy chọn "Loading countries..."
        locationSelect.append('<option selected disabled value="">Choose your countries</option>'); // Thêm tùy chọn mặc định

        // Lặp qua dữ liệu trả về từ API và thêm mỗi quốc gia vào dropdown
        data.forEach(country => {
            const countryName = country.name.common; // Lấy tên quốc gia
            const countryCode = country.cca2; // Lấy mã quốc gia
            locationSelect.append(`<option value="${countryCode}">${countryName}</option>`); // Thêm quốc gia vào dropdown
        });
    })
        .fail(function () {
            // Nếu lấy dữ liệu thất bại, hiển thị thông báo lỗi trong dropdown
            $('#location').html('<option selected disabled value="">Không thể tải quốc gia</option>');
        });
});
