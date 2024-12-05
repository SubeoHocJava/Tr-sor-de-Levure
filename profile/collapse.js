
$(".collapse-content").hide()
$(".collapse-btn").on("click", function() {
	var content = $(this).siblings(".collapse-content");
    content.toggle(500)
});
