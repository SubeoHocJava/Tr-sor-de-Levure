/**
 * Quản lí mở các đề mục
 */
$(document).ready(function() {
	$('.primary-color-hover').on('click', function(event) {
		event.stopPropagation();  // Ngừng sự kiện lan truyền lên phần tử cha
		var index = $('.primary-color-hover').index(this);
		setActiveSmallTag(index);
	});
	// Sự kiện cho các mục lớn
	$('#userMenuAccordion .accordion-item').on('click', function(event) {
		event.stopPropagation();  // Ngừng sự kiện lan truyền lên phần tử cha
		var index = $('#userMenuAccordion .accordion-item').index(this);
		var smallIndex = index === 0 ? 0 : $('.infor-tag').length - 1;
		setActiveSmallTag(smallIndex);
	});

	// Hàm set active cho các mục nhỏ
	function setActiveSmallTag(index) {
		$('.primary-color-hover').removeClass('primary-color-active'); // Xóa active cũ
		$('.primary-color-hover').eq(index).addClass('primary-color-active'); // Đặt active mới
		var tag = $('.infor-tag').eq(index); // Lấy nội dung theo index
		tag.removeClass('d-none'); // Hiển thị nội dung
		$('.infor-tag').not(tag).addClass('d-none'); // Ẩn các nội dung còn lại
	}
});
