// Lấy tham chiếu tới tất cả các trường mật khẩu và biểu tượng "mắt"
const passwordFields = document.querySelectorAll('input[type="password"]');
const eyeIcons = document.querySelectorAll('.eye-icon');

// Thêm sự kiện khi người dùng nhấp vào biểu tượng "mắt"
eyeIcons.forEach((eyeIcon, index) => {
    eyeIcon.addEventListener('click', function () {
        // Thay đổi kiểu hiển thị của trường mật khẩu giữa 'password' và 'text'
        const passwordField = passwordFields[index];
        const type = passwordField.type === 'password' ? 'text' : 'password';
        passwordField.type = type;

        // Thay đổi biểu tượng "mắt" thành "mắt" khi mật khẩu được hiển thị và ngược lại
        if (passwordField.type === 'text') {
            this.classList.remove('fa-eye-slash');
            this.classList.add('fa-eye');
        } else {
            this.classList.remove('fa-eye');
            this.classList.add('fa-eye-slash');
        }
    });
});


// Khởi tạo jQuery UI Datepicker cho trường ngày sinh
$("#registration-form-dob").datepicker({
    changeMonth: true,  // Cho phép thay đổi tháng
    changeYear: true,   // Cho phép thay đổi năm
    yearRange: "1900:2020", // Giới hạn năm từ 1900 đến 2020
    dateFormat: "dd/mm/yy"  // Định dạng ngày tháng là mm/dd/yy
});


