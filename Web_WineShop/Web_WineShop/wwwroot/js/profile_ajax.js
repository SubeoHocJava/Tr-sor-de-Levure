$(function () {
    // Xử lý sự kiện submit của form
    $('.star').on('click', function () {

        const container = $(this).parent();
        const value = container.data('value');
        const id = container.data('id');
        $.ajax({
            url: '/Profile/Rating/' + id + '?value=' + value,
            type: 'GET'
        })
    })
    $('#sign-out').on('click', function () {
        $.ajax({
            url: '/Profile/LogOut',
            type: 'GET',
            success: function (response) {
                if (response.redirectUrl) {
                    window.location.href = response.redirectUrl;
                }
            }
        })
    });
    $('#change-infor-btn').on("click", function () {
        var formData = $('#my-details-form').serialize();
        $.ajax({
            url: '/Profile/Edit',
            type: 'POST',
            data: formData,
            success: function (response) {
                if (response.success) {
                    alert(123)
                }
            }
        });
    })
    $('#change-password-form').on("submit", function (event) {
        event.preventDefault();
        var formData = $(this).serialize();

        $.ajax({
            url: '/Profile/ChangePass',
            type: 'POST',
            data: formData,
            success: function (response) {
                if (response.success) {
                    $('#success-message').fadeIn();
                    setTimeout(function () {
                        $('#success-message').fadeOut();
                    }, 3000);
                }
            },
            error: function () {
                alert('There was an error processing your request.');
            }
        });
    });
});