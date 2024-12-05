/**
 * Check quá trình nhập form
 */

$(document).ready(function() {
	// Hiển thị ảnh xem trước khi người dùng tải ảnh lên
	$('#imageUpload').on('change', function() {
		const file = this.files[0];
		if (file) {
			const reader = new FileReader();
			reader.onload = function(e) {
				$('#previewImage').attr('src', e.target.result);
			};
			reader.readAsDataURL(file);
		}
	});

	// Hàm kiểm tra trường nhập
	function checkInput(inputSelector, errorSelector, validateFunc = null) {
		const value = $(inputSelector).val().trim();
		const isValid = value !== '' && (validateFunc ? validateFunc(value) : true);
		if (isValid) {
			$(errorSelector).addClass('d-none');
		} else {
			$(errorSelector).removeClass('d-none');
		}
		return isValid;
	}

	// Kiểm tra và gửi form người dùng
	$('#submitButton').on('click', function() {
		let isValid = true;

		// Kiểm tra các trường nhập
		isValid &= checkInput('#name', '#nameError');
		isValid &= checkInput('#email', '#emailError', validateEmail);
		isValid &= checkInput('#phone', '#phoneError');
		isValid &= checkInput('#birthday', '#birthdayError');

		// Nếu hợp lệ, submit form
		if (isValid) {
			$('#userForm').submit();
		}
	});

	// Hàm kiểm tra email hợp lệ
	function validateEmail(email) {
		const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
		return re.test(email);
	}

	// Quản lý địa chỉ
	$('#addressSubmitButton').click(function() {
		const fullName = $('#fullName').val();
		const phoneNumber = $('#phoneNumber').val();
		const address = $('#address').val();

		// Kiểm tra nếu tất cả các trường đều có giá trị
		if (fullName && phoneNumber && address) {
			// Hiển thị thông tin đã nhập vào thẻ hiển thị
			$('#displayFullName').text(fullName);
			$('#displayPhoneNumber').text(phoneNumber);
			$('#displayAddress').text(address);

			// Hiển thị thẻ thông tin địa chỉ và ẩn form nhập địa chỉ
			$('#addressDisplay').show();
			$('#addressForm').hide();
		} else {
			// Hiển thị thông báo lỗi nếu một trong các trường bị thiếu
			if (!fullName) $('#fullNameError').removeClass('d-none');
			if (!phoneNumber) $('#phoneNumberError').removeClass('d-none');
			if (!address) $('#addressError').removeClass('d-none');
		}
	});

	// Tắt lỗi khi người dùng bắt đầu nhập lại
	$('#fullName, #phoneNumber, #address').on('input', function() {
		$(this).siblings('small').addClass('d-none');
	});

	// Khi nhấn nút "Sửa địa chỉ"
	$('#editAddressButton').click(function() {
		// Hiển thị lại form nhập địa chỉ và điền lại các giá trị vào form
		$('#addressForm').show();
		$('#addressDisplay').hide();
		$('#fullName').val($('#displayFullName').text());
		$('#phoneNumber').val($('#displayPhoneNumber').text());
		$('#address').val($('#displayAddress').text());
	});
});
