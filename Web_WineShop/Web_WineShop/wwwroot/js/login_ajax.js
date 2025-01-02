$(document).ready(function () {

    // XỬ LÍ ĐĂNG NHẬP
    $('#loginForm').submit(function (event) {
        event.preventDefault(); // Ngừng hành động gửi form

        var email = $('#login-email').val();
        var password = $('#login-password').val();

        $.ajax({
            url: loginUrl, // URL gửi yêu cầu
            type: 'POST',
            data: { email: email, password: password },
            success: function (response) {
                if (response.success) {
                    window.location.href = response.redirectUrl; // Chuyển hướng sau khi đăng nhập thành công
                } else {
                    $('#error-message').text(response.message); // Hiển thị thông báo lỗi
                }
            },
            error: function () {
                $('#error-message').text('Có lỗi xảy ra. Vui lòng thử lại!');
            }
        });
    });


    // XỬ LÍ ĐĂNG KÍ
    $('#registration-form').submit(function (event) {
        event.preventDefault(); 

        var fullName = $('#registration-form-fullname').val();
        var dob = $('#registration-form-dob').val();
        var email = $('#registration-form-email').val();
        var phone = $('#registration-form-phone').val();
        var country = $('#country').val(); 
        var gender = $('input[name="gender"]:checked').val(); 
        var password = $('#registration-form-password').val();
        var passwordConfirm = $('#registration-form-password-confirm').val();

        $.ajax({
            url: regisUrl, 
            type: 'POST',
            data: {
                fullName: fullName,
                dob: dob,
                email: email,
                phone: phone,
                country: country,
                gender: gender,
                password: password,
                passwordConfirm: passwordConfirm
            },
            success: function (response) {
                if (response.success) {       
                    $('#error-message').hide();
                    $('#successMessage').text(response.message).show();
                    
                    setTimeout(function () {
                        $('#successMessage').fadeOut();
                        window.location.href = response.redirectUrl; 
                    }, 500); // 0.5 giây

                } else {                   
                    $('#error-message').text(response.message);
                }
            },
            error: function () {              
                $('#error-message').text('Có lỗi xảy ra. Vui lòng thử lại!');
            }
        });
    });

    // XỬ LÍ QUÊN MẬT KHẨU
    $("#forgotPasswordForm").on("submit", function (e) {
        e.preventDefault();

        var email = $("#forgot-email").val();
        var formData = { email: email };

        $("#errorMessage").hide();
        $("#successMessage").hide();

        $.ajax({
            url: forgotUrl,
            type: 'POST',
            data: formData,
            success: function (response) {
                if (response.success) {
                    $("#successMessage").text(response.message).show();
                } else {
                    $("#errorMessage").text(response.message).show();
                }
            },
            error: function () {
                $("#errorMessage").text("Đã xảy ra lỗi.Vui lòng thử lại").show();
            }
        });
    });
});
