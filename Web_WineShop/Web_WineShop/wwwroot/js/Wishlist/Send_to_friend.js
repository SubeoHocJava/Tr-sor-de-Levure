(function () {
    'use strict';

    angular
        .module('app')
        .controller('Send_to_friend', Send_to_friend);

    Send_to_friend.$inject = ['$location'];

    function Send_to_friend($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Send_to_friend';

        // Định nghĩa các quy tắc xác thực
        vm.validationRules = {
            friend_name: {
                required: true,
                required_err_msg: "Name required",
                rules: [{
                    rule: "length",
                    min: 1,
                    max: 255,
                    err_msg: "Length must be between 1 and 255 characters"
                }]
            },
            friend_email: {
                required: true,
                required_err_msg: "Email required",
                rules: [{
                    rule: "email",
                    err_msg: "Please enter a valid email address"
                }]
            },
            your_name: {
                required: true,
                required_err_msg: "Your name is required",
                rules: [{
                    rule: "length",
                    min: 1,
                    max: 255,
                    err_msg: "Length must be between 1 and 255 characters"
                }]
            },
            your_email: {
                required: true,
                required_err_msg: "Your email is required",
                rules: [{
                    rule: "email",
                    err_msg: "Please enter a valid email address"
                }]
            },
            g_recaptcha_response: {
                required: true,
                required_err_msg: "Please complete the reCAPTCHA"
            }
        };

        vm.formData = {}; // Lưu trữ dữ liệu form

        vm.submitForm = function (form) {
            // Xóa lỗi trước đó
            clearErrors(form);

            // Kiểm tra xác thực form
            const errors = validateForm(form, vm.validationRules);

            if (Object.keys(errors).length === 0) {
                // Nếu không có lỗi, gửi form
                console.log('Form is valid. Submitting...');
                // Logic gửi form dữ liệu ở đây (ví dụ, gọi API)
            } else {
                // Hiển thị lỗi xác thực
                showErrors(errors, form);
            }
        };

        // Kiểm tra toàn bộ form
        function validateForm(form, rules) {
            const errors = {};

            for (const [field, settings] of Object.entries(rules)) {
                const input = form.querySelector(`[name="${field}"]`);
                if (!input) continue;

                const fieldErrors = [];
                if (settings.required && !input.value.trim()) {
                    fieldErrors.push(settings.required_err_msg);
                }

                if (settings.rules) {
                    for (const rule of settings.rules) {
                        if (rule.rule === "length") {
                            const length = input.value.trim().length;
                            if (length < rule.min || length > rule.max) {
                                fieldErrors.push(rule.err_msg);
                            }
                        } else if (rule.rule === "email") {
                            if (!validateEmail(input.value)) {
                                fieldErrors.push(rule.err_msg);
                            }
                        }
                    }
                }

                if (fieldErrors.length > 0) {
                    errors[field] = fieldErrors[0];
                }
            }

            return errors;
        }

        // Hỗ trợ xóa lỗi
        function clearErrors(form) {
            const errorElements = form.querySelectorAll(".checkout-select-message--error");
            errorElements.forEach((errorElement) => {
                errorElement.style.display = "none";
            });
        }

        // Hỗ trợ hiển thị lỗi
        function showErrors(errors, form) {
            for (const [field, message] of Object.entries(errors)) {
                const input = form.querySelector(`[name="${field}"]`);
                if (input) {
                    const errorElement = input.nextElementSibling;
                    errorElement.textContent = message;
                    errorElement.style.display = "block";
                }
            }
        }

        // Hỗ trợ kiểm tra email
        function validateEmail(email) {
            const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return regex.test(email);
        }
    }
})();

document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('wishlist_friend_form');

    // Lấy các trường input
    const friendName = document.getElementById('friend_name');
    const friendEmail = document.getElementById('friend_email');
    const yourName = document.getElementById('your_name');
    const yourEmail = document.getElementById('your_email');

    // Lấy các thông báo lỗi
    const friendNameError = friendName.nextElementSibling; // Thông báo lỗi cho Friend's Name
    const friendEmailError = friendEmail.nextElementSibling; // Thông báo lỗi cho Friend's Email
    const yourNameError = yourName.nextElementSibling; // Thông báo lỗi cho Your Name
    const yourEmailError = yourEmail.nextElementSibling; // Thông báo lỗi cho Your Email

    // Thêm sự kiện khi người dùng nhập liệu
    friendName.addEventListener('input', function () {
        if (friendName.value.trim() !== '') {
            friendNameError.style.display = 'none';  // Ẩn thông báo lỗi khi có nhập liệu
        } else {
            friendNameError.style.display = 'block';  // Hiện thông báo lỗi nếu trường trống
        }
    });

    friendEmail.addEventListener('input', function () {
        if (friendEmail.value.trim() !== '') {
            friendEmailError.style.display = 'none';  // Ẩn thông báo lỗi khi có nhập liệu
        } else {
            friendEmailError.style.display = 'block';  // Hiện thông báo lỗi nếu trường trống
        }
    });

    yourName.addEventListener('input', function () {
        if (yourName.value.trim() !== '') {
            yourNameError.style.display = 'none';  // Ẩn thông báo lỗi khi có nhập liệu
        } else {
            yourNameError.style.display = 'block';  // Hiện thông báo lỗi nếu trường trống
        }
    });

    yourEmail.addEventListener('input', function () {
        if (yourEmail.value.trim() !== '') {
            yourEmailError.style.display = 'none';  // Ẩn thông báo lỗi khi có nhập liệu
        } else {
            yourEmailError.style.display = 'block';  // Hiện thông báo lỗi nếu trường trống
        }
    });

    // Kiểm tra và gửi form khi người dùng nhấn nút Submit
    form.addEventListener('submit', function (e) {
        e.preventDefault();  // Ngừng gửi form mặc định

        let isValid = true;

        // Kiểm tra tất cả các trường
        if (friendName.value.trim() === '') {
            friendNameError.style.display = 'block';
            isValid = false;
        } else {
            friendNameError.style.display = 'none';
        }

        if (friendEmail.value.trim() === '') {
            friendEmailError.style.display = 'block';
            isValid = false;
        } else {
            friendEmailError.style.display = 'none';
        }

        if (yourName.value.trim() === '') {
            yourNameError.style.display = 'block';
            isValid = false;
        } else {
            yourNameError.style.display = 'none';
        }

        if (yourEmail.value.trim() === '') {
            yourEmailError.style.display = 'block';
            isValid = false;
        } else {
            yourEmailError.style.display = 'none';
        }

        // Nếu tất cả các trường hợp lệ, gửi form
        if (isValid) {
            form.submit();  // Gửi form nếu không có lỗi
        }
    });
});
