/**
 * Link 
 */
$(function () {
    $('link').on('click', function () {
        window.location.href = $(this).data('href');
    });
})


