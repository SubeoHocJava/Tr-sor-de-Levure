$(document).ready(function () {
    $('.recieved_order-btn').on('click', function () {
        $(this).prev('.buy_again-btn').removeClass('disabled-btn');
        $(this).addClass('disabled-btn'); 
    });
});