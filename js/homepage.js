const featureMenuTags = $('.menu-tag-btn');
const featureMenuItems = $('.menu-item');

featureMenuTags.each(function(index) {
    $(this).on('click', function() {
        $(this).addClass('menu-tag-btn-select').removeClass('menu-tag-btn-hover');
        featureMenuItems.eq(index).removeClass('d-none');

        featureMenuItems.each(function(i) {
            $(this).toggleClass('d-none', i !== index);
        });

        featureMenuTags.each(function(i) {
            $(this).toggleClass('menu-tag-btn-select', i === index);
            $(this).toggleClass('menu-tag-btn-hover', i !== index);
        });
    });
});

const slidesShow =5;
const slidesScroll = 5;
$('.brand-list').slick({
    infinite: true,
    slidesToShow: slidesShow,
    slidesToScroll: slidesScroll,
    autoplay: true,
    accessibility: true, 
    focusOnSelect: false,
    autoplaySpeed: 3000,
    arrows: false,
});



