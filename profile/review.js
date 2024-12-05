/**
 * Sự kiện cho đánh giá sản phẩm
 */
// Hàm mở phần đánh giá
$(document).ready(function() {
	$('.open-rating-container').on('click', function() {
		var index = $('.open-rating-container').index(this);
		openRatingContainer(index);
	});


	$('.cancelRating').on('click', function() {
		var index = $('.cancelRating').index(this);
		var stars = $('.rating-container').eq(index).find('.star');
		rating(stars, 0);
		closeRatingContainer(index);
	});

	$('.comfirmRating').on('click', function() {
		var index = $('.comfirmRating').index(this);
		closeRatingContainer(index);
		var btn = $('.open-rating-container').eq(index);
		btn.addClass('d-none');
		btn.siblings('.btn-link').removeClass('d-none');
	});

	$('.star').on('mouseenter', function() {
		var container = $(this).closest('.rating-container');
		var stars = container.find('.star');
		var value = stars.index(this) + 1;
		rating(stars, value);
	})
	$('.star').on('mouseleave', function() {
		var container = $(this).closest('.rating-container');
		var stars = container.find('.star');
		var value = container.data('rating');
		rating(stars, value);
	})
	$('.star').on('click', function() {
		var container = $(this).closest('.rating-container');
		var stars = container.find('.star');
		var value = stars.index(this) + 1;
		container.data('rating', value);
		rating(stars, value);
	});

	function rating(stars, value) {
		for (var i = 0; i < stars.length; i++) {
			if (i < value) {
				stars.eq(i).addClass('star_active');
			} else {
				stars.eq(i).removeClass('star_active');
			}
		}
	}
	function closeRatingContainer(index) {
		$('.rating-container').eq(index).addClass('d-none');
		$('.open-rating-container').eq(index).removeClass('d-none');
	}
	function openRatingContainer(index) {
		$('.rating-container').eq(index).removeClass('d-none');
		$('.open-rating-container').eq(index).addClass('d-none');
	}
});