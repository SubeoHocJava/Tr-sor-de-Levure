$(document).ready(function () {
    var normalStar = '&#9734;'; // Empty star
    var filledStar = '&#9733;'; // Filled star

    // Handle click on a star
    $('.stars').each(function(){
        getRating(this);
    });
    $('.star').click(function () {
        var index = $(this).parent('.stars').children('.star').index(this); // Get the index of the clicked star
        $(this).parent('.stars').addClass('stars-selected');
        $(this).parent('.stars').data('value', index + 1);
        $(this).prevAll().html(filledStar).addClass('stars_active');
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
        getRating(this);
    });
    function getRating(stars) {
        var rating = $(stars).data('value');
        $(stars).children('.star').each(function (index) {
            if (index < rating) {
                $(this).html(filledStar).addClass('star_active');
            } else {
                $(this).html(normalStar).removeClass('star_active');
            }
        });
    }
});
