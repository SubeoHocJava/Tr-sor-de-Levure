$(document).ready(function () {
    var normalStar = '&#9734;'; // Empty star
    var filledStar = '&#9733;'; // Filled star
    var rating = 0;

    // Handle click on a star
    $('.star').click(function () {
        var index = $(this).index(); // Get the index of the clicked star
        rating = index + 1; // Update the rating value
        $(this).prevAll().html(filledStar).addClass('star_active');
        $(this).html(filledStar).addClass('star_active');
        $(this).nextAll().html(normalStar).removeClass('star_active');
    });

    // Handle hover over a star
    $('.star').mouseenter(function () {
        $(this).prevAll().html(filledStar).addClass('star_active');
        $(this).html(filledStar).addClass('star_active');
        $(this).nextAll().html(normalStar).removeClass('star_active')
    });

    // Handle mouse leaving the stars area
    $('.stars').mouseleave(function () {
        $('.star').each(function (index) {
            if (index < rating) {
                $(this).html(filledStar).addClass('star_active'); // Filled star
            } else {
                $(this).html(normalStar).removeClass('star_active'); // Empty star
            }
        });
    });
});
